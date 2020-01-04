namespace contpaqi_sql_interface.Forms
{
    partial class Frm_Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_host = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_pass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_srcDir = new System.Windows.Forms.TextBox();
            this.btn_srcDir = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host/Instancia:";
            // 
            // tbx_host
            // 
            this.tbx_host.Location = new System.Drawing.Point(120, 6);
            this.tbx_host.Name = "tbx_host";
            this.tbx_host.Size = new System.Drawing.Size(241, 20);
            this.tbx_host.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Usuario:";
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(120, 32);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(241, 20);
            this.tbx_user.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contraseña:";
            // 
            // tbx_pass
            // 
            this.tbx_pass.Location = new System.Drawing.Point(120, 58);
            this.tbx_pass.Name = "tbx_pass";
            this.tbx_pass.PasswordChar = '•';
            this.tbx_pass.Size = new System.Drawing.Size(241, 20);
            this.tbx_pass.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Directorio de origen:";
            // 
            // tbx_srcDir
            // 
            this.tbx_srcDir.Location = new System.Drawing.Point(120, 84);
            this.tbx_srcDir.Name = "tbx_srcDir";
            this.tbx_srcDir.Size = new System.Drawing.Size(241, 20);
            this.tbx_srcDir.TabIndex = 1;
            // 
            // btn_srcDir
            // 
            this.btn_srcDir.Location = new System.Drawing.Point(367, 82);
            this.btn_srcDir.Name = "btn_srcDir";
            this.btn_srcDir.Size = new System.Drawing.Size(26, 23);
            this.btn_srcDir.TabIndex = 2;
            this.btn_srcDir.Text = "...";
            this.btn_srcDir.UseVisualStyleBackColor = true;
            this.btn_srcDir.Click += new System.EventHandler(this.btn_srcDir_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(314, 112);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 3;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // Frm_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 147);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_srcDir);
            this.Controls.Add(this.tbx_srcDir);
            this.Controls.Add(this.tbx_pass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_user);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_host);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Config";
            this.Text = "Configurar";
            this.Load += new System.EventHandler(this.Frm_Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_host;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_pass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_srcDir;
        private System.Windows.Forms.Button btn_srcDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button btn_guardar;
    }
}