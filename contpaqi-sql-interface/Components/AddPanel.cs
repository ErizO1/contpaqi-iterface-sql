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
    public partial class AddPanel : UserControl
    {
        private string _contpaqSystem = null;
        private AddConnection _connection = null;
        private AddPanelEntry[] _entries = null;

        public AddConnection Connection
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
        public AddPanel()
        {
            InitializeComponent();
            this.dgv_databases.AutoGenerateColumns = false;
        }

        public void UpdateRows()
        {
            this._entries = Connection.GetAddDatabasesForAttach();
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
                this.UpdateRows();

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

        private void AddPanel_Load(object sender, EventArgs e)
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

        private void chb_attach_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chb_attach.Checked)
            {
                this.Connection.SelectedEntries = this._entries.ToList();
            } else
            {
                this.Connection.SelectedEntries.Clear();
            }
        }
    }
}
