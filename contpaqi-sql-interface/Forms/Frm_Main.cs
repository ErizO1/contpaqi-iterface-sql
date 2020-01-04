using contpaqi_sql_interface.Components;
using contpaqi_sql_interface.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace contpaqi_sql_interface.Forms
{
    public partial class Frm_Main : Form
    {
        CoreDB databaseConn = CoreDB.Instance;
        List<DatabaseAction> actions = new List<DatabaseAction>();

        public Frm_Main()
        {
            InitializeComponent();

            databaseConn.AddOnConnectingEventHandler(() => this.lbl_status.Text = "Conectando");
            databaseConn.AddOnConnectedEventHandler(() => {
                this.lbl_status.Text = databaseConn.PhysicalLocation;
                this.panelContabilidad.Connection = databaseConn.contabilidadConnection;
                this.panelNominas.Connection = databaseConn.nominasConnection;
                this.panelComercial.Connection = databaseConn.comercialConnection;
                this.panelAdd.Connection = databaseConn.addConnection;
            });
        }

        private void init()
        {
            var settings = Properties.Settings.Default;
            bool ready = false;

            while (!ready)
            {
                if (!settings.Ready)
                {
                    Form frm_config = new Frm_Config();
                    frm_config.ShowDialog();

                    if (!settings.Ready) {
                        Application.Exit();
                        return;
                    }

                }

                databaseConn.Host = settings.Host;
                databaseConn.User = settings.User;
                databaseConn.Pass = settings.Pass;
                databaseConn.Database = "master";
                databaseConn.SourceDirectory = settings.SourceDirectory;

                try
                {
                    databaseConn.TestConnection();
                    settings.Ready = true;
                    settings.Save();
                    ready = true;
                }
                catch (Exception ex)
                {
                    settings.Ready = false;
                    settings.Save();
                    MessageBox.Show(
                        $"Error: ${ex.Message}",
                        "Error al conectar con base de datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            databaseConn.Connect();
            this.actions.Clear();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.init();
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            databaseConn.Disconnect();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm_config = new Frm_Config();
            var result = frm_config.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (this.databaseConn.IsConnected)
                {
                    databaseConn.Disconnect();
                }
                this.init();
            }
        }

        private void recargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Desea recargar? Se perderán todos sus cambios",
                "Recargar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (this.databaseConn.IsConnected)
                {
                    databaseConn.Disconnect();
                }
                this.init();
            }
        }

        private void tabPanel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPanel1.SelectedTab == tabResumen)
            {
                List<Dictionary<string, object>> allEntries = new List<Dictionary<string, object>>();
                var actions = this.databaseConn.ScheduledActions;

                //  Fill the list for all the entries of the system, excluding ADD
                foreach (var entry in panelContabilidad.Connection.SelectedEntries)
                {
                    var pair = new Dictionary<string, object>();
                    pair.Add("system", DatabaseActionSystemName.Contabilidad);
                    pair.Add("entry", entry);
                    allEntries.Add(pair);
                }

                foreach (var entry in panelNominas.Connection.SelectedEntries)
                {
                    var pair = new Dictionary<string, object>();
                    pair.Add("system", DatabaseActionSystemName.Nominas);
                    pair.Add("entry", entry);
                    allEntries.Add(pair);
                }

                foreach (var entry in panelComercial.Connection.SelectedEntries)
                {
                    var pair = new Dictionary<string, object>
                    {
                        { "system", DatabaseActionSystemName.Comercial },
                        { "entry", entry }
                    };
                    allEntries.Add(pair);
                }

                foreach (var entry in panelAdd.Connection.SelectedEntries)
                {
                    var pair = new Dictionary<string, object>
                    {
                        { "system", DatabaseActionSystemName.ADD },
                        { "entry", entry }
                    };
                    allEntries.Add(pair);
                }

                actions.Clear();

                foreach (var entry in allEntries)
                {
                    string dbName = "";
                    string filenameMDF = "";
                    string filenameLDF = "";
                    if ((DatabaseActionSystemName)entry["system"] == DatabaseActionSystemName.ADD)
                    {
                        AddPanelEntry addPanelEntry = (AddPanelEntry)entry["entry"];

                        foreach (var databaseType in new string[] { "DocumentContent", "DocumentMetadata", "OthersContent", "OthersMetadata" })
                        {
                            dbName = addPanelEntry.GetType().GetProperty(databaseType).GetValue(
                                addPanelEntry,
                                null).ToString();

                            filenameMDF = addPanelEntry.GetType().GetProperty($"{databaseType}MDF").GetValue(
                                addPanelEntry,
                                null).ToString();

                            filenameLDF = addPanelEntry.GetType().GetProperty($"{databaseType}LDF").GetValue(
                                addPanelEntry,
                                null).ToString();

                            if (!File.Exists($@"{databaseConn.PhysicalLocation}\{filenameMDF}"))
                            {
                                actions.Add(new DatabaseAction
                                {
                                    Action = "Copiar",
                                    Company = addPanelEntry.Nombre,
                                    DBName = dbName,
                                    FilenameMDF = filenameMDF,
                                    FilenameLDF = filenameLDF,
                                    System = (DatabaseActionSystemName)entry["system"]
                                });
                            }

                            actions.Add(new DatabaseAction
                            {
                                Action = "Adjuntar",
                                Company = addPanelEntry.Nombre,
                                DBName = dbName,
                                FilenameMDF = filenameMDF,
                                FilenameLDF = filenameLDF,
                                System = (DatabaseActionSystemName)entry["system"]
                            });
                        }
                    }
                    else
                    {
                        PanelEntry panelEntry = (PanelEntry)entry["entry"];

                        // Check if destination file is not there, so we shcedule the copy
                        if (!File.Exists($@"{databaseConn.PhysicalLocation}\{panelEntry.ArchivoMDF}"))
                        {
                            actions.Add(new DatabaseAction
                            {
                                Action = "Copiar",
                                Company = panelEntry.Empresa,
                                DBName = panelEntry.Nombre,
                                FilenameMDF = panelEntry.ArchivoMDF,
                                FilenameLDF = panelEntry.ArchivoLDF,
                                System = (DatabaseActionSystemName)entry["system"]
                            });
                        }

                        actions.Add(new DatabaseAction
                        {
                            Action = "Adjuntar",
                            Company = panelEntry.Empresa,
                            DBName = panelEntry.Nombre,
                            FilenameMDF = panelEntry.ArchivoMDF,
                            FilenameLDF = panelEntry.ArchivoLDF,
                            System = (DatabaseActionSystemName)entry["system"]
                        });
                    }
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = actions;
                this.dgv_actions.DataSource = bs;

                this.lbl_actionsQty.Text = $"Cantidad de acciones: {actions.Count}";

                this.btn_apply.Enabled = Convert.ToBoolean(actions.Count);
            }
            if (tabPanel1.SelectedTab == tabADD)
            {
                this.panelAdd.UpdateRows();
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            //databaseConn.ApplyChanges();
            //MessageBox.Show("Acciones realizadas con éxito", "Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form progress = new Frm_Progress();
            progress.ShowDialog();
            this.init();
        }
    }
}
;
