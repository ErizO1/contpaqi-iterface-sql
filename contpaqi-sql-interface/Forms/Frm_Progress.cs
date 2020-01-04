using contpaqi_sql_interface.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contpaqi_sql_interface.Forms
{
    public partial class Frm_Progress : Form
    {
        private CoreDB coreDB = CoreDB.Instance;

        public Frm_Progress()
        {
            InitializeComponent();
        }

        private void Frm_Progress_Load(object sender, EventArgs e)
        {
            while (!this.IsHandleCreated)
                System.Threading.Thread.Sleep(100);
            this.coreDB.ClearOnProgressEventHandlers();
            this.coreDB.AddOnProgressEventHandler(step =>
            {
                var actions = this.coreDB.ScheduledActions;
                this.BeginInvoke((MethodInvoker)delegate
                {
                    this.pb_progress.Value = (100 / actions.Count) * step;
                    lbl_progress.Text = $"{step}/{actions.Count}";
                    if (step == actions.Count)
                    {
                        btn_close.Enabled = true;
                        btn_close.Enabled = true;
                        lbl_action.Text = "Finalizado";
                    } else
                    {
                        lbl_action.Text = $"{actions[step].Action}: {actions[step].DBName}";
                    }
                });
            });

            this.coreDB.ApplyChanges();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
