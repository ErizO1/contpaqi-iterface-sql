using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contpaqi_sql_interface.Forms
{
    public partial class Frm_Config : Form
    {
        public Frm_Config()
        {
            InitializeComponent();
        }

        private void Frm_Config_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            if (settings.Ready)
            {
                this.tbx_host.Text = settings.Host;
                this.tbx_user.Text = settings.User;
                this.tbx_pass.Text = settings.Pass;
                this.tbx_srcDir.Text = settings.SourceDirectory;
            } else
            {
                this.tbx_host.Text = @"(local)\COMPAC";
                this.tbx_user.Text = "sa";
                this.tbx_pass.Text = "";
                this.tbx_srcDir.Text = "";
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                btn_guardar.Enabled = false;
                btn_guardar.Text = "Probando...";

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = this.tbx_host.Text;
                builder.UserID = this.tbx_user.Text;
                builder.Password = this.tbx_pass.Text;
                builder.InitialCatalog = "master";

                var connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                connection.Close();

                var settings = Properties.Settings.Default;
                settings.Host = this.tbx_host.Text;
                settings.User = this.tbx_user.Text;
                settings.Pass = this.tbx_pass.Text;
                settings.SourceDirectory = this.tbx_srcDir.Text;
                settings.Ready = true;
                settings.Save();

                MessageBox.Show("Configuración guardada con éxito", "Configuración guardada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();

            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error al comprabar conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_guardar.Enabled = true;
                btn_guardar.Text = "Guardar";
            }
        }

        private void btn_srcDir_Click(object sender, EventArgs e)
        {
            var result = this.folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tbx_srcDir.Text = this.folderBrowser.SelectedPath;
            }
        }
    }
}
