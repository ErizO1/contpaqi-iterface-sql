using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using contpaqi_sql_interface.DB;

namespace contpaqi_sql_interface.Components
{
    public partial class SystemPanel : UserControl
    {
        private string _contpaqSystem = null;
        private SystemConnection _connection = null;
        private ActualPanelEntry[] _entries = null;

        public SystemConnection Connection
        {
            get
            {
                return this._connection;
            }
            set
            {
                this._connection = value;
                init();
            }
        }
        public string ContpaqSystem 
        {
            get
            {
                return this._contpaqSystem;
            }
            set
            {
                this._contpaqSystem = value;
                this.lbl_system.Text = "Sistema: " + value;
            }
        }
        public SystemPanel()
        {
            InitializeComponent();
            this.dgv_databases.AutoGenerateColumns = false;
        }

        private void init()
        {
            if (this.Connection == null)
            {
                lbl_compStatus.Text = "Conector no inicializado";
                return;
            }

            if (this.Connection.IndexIsAttached)
            {
                this.lbl_compStatus.Text = "";
                PanelEntry[] entradas = Connection.GetDatabasesForAttach();
                this._entries = entradas.Select(e => new ActualPanelEntry
                {
                    Empresa = e.Empresa,
                    Nombre = e.Nombre,
                    ArchivoMDF = e.ArchivoMDF,
                    ArchivoLDF = e.ArchivoLDF,
                    Adjuntar = false
                }).ToArray();

                BindingSource bs = new BindingSource();
                bs.DataSource = this._entries;
                this.dgv_databases.DataSource = bs;
            }
            else if (this.Connection.SourceIndexExists)
            {
                this.btn_attach.Text = "Adjuntar index";
                this.lbl_compStatus.Text = "Index no adjunto";
            } else
            {
                this.btn_attach.Enabled = false;
                this.lbl_compStatus.Text = "Index no encontrado";
            }
        }

        private void SystemPanel_Load(object sender, EventArgs e)
        {
            //this.init();
        }

        private void btn_attach_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Connection.IndexIsAttached)
                {
                    var result = MessageBox.Show("Ya hay un índice adjunto, ¿desea sustituirlo?", "Reemplazar Indice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Connection.AttachIndex(true);
                        this.init();
                    } else
                    {
                        return;
                    }
                } else
                {
                    this.Connection.AttachIndex(false);
                    this.init();
                }
                MessageBox.Show($"Índice de {this.ContpaqSystem} adjunto con éxito", "Índice adjunto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_selectAll_Click(object sender, EventArgs e)
        {
            Connection.SelectedEntries.Clear();
            foreach (var entry in this._entries)
            {
                entry.Adjuntar = true;
                Connection.SelectedEntries.Add(entry);
            }
            this.dgv_databases.Refresh();
        }

        private void dgv_databases_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && dgv_databases.CurrentCell != null)
            {
                if (Convert.ToBoolean(dgv_databases.CurrentCell.Value))
                {
                    Connection.SelectedEntries.Add((PanelEntry)dgv_databases.CurrentRow.DataBoundItem);
                } else
                {
                    Connection.SelectedEntries.Remove((PanelEntry)dgv_databases.CurrentRow.DataBoundItem);
                }
            }
        }
    }
}
