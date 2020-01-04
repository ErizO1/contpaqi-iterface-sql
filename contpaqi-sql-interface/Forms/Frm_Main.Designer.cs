namespace contpaqi_sql_interface.Forms
{
    partial class Frm_Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPanel1 = new System.Windows.Forms.TabControl();
            this.tabContabilidad = new System.Windows.Forms.TabPage();
            this.tabNominas = new System.Windows.Forms.TabPage();
            this.tabComercial = new System.Windows.Forms.TabPage();
            this.tabADD = new System.Windows.Forms.TabPage();
            this.tabResumen = new System.Windows.Forms.TabPage();
            this.btn_apply = new System.Windows.Forms.Button();
            this.dgv_actions = new System.Windows.Forms.DataGridView();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArchivoMDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArchivoLDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelContabilidad = new contpaqi_sql_interface.Components.SystemPanel();
            this.panelNominas = new contpaqi_sql_interface.Components.SystemPanel();
            this.panelComercial = new contpaqi_sql_interface.Components.SystemPanel();
            this.panelAdd = new contpaqi_sql_interface.Components.AddPanel();
            this.lbl_actionsQty = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPanel1.SuspendLayout();
            this.tabContabilidad.SuspendLayout();
            this.tabNominas.SuspendLayout();
            this.tabComercial.SuspendLayout();
            this.tabADD.SuspendLayout();
            this.tabResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_actions)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recargarToolStripMenuItem,
            this.configuraciónToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // recargarToolStripMenuItem
            // 
            this.recargarToolStripMenuItem.Name = "recargarToolStripMenuItem";
            this.recargarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.recargarToolStripMenuItem.Text = "Recargar";
            this.recargarToolStripMenuItem.Click += new System.EventHandler(this.recargarToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.configuraciónToolStripMenuItem.Text = "Configuración...";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 585);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(45, 17);
            this.lbl_status.Text = "Version";
            // 
            // tabPanel1
            // 
            this.tabPanel1.Controls.Add(this.tabContabilidad);
            this.tabPanel1.Controls.Add(this.tabNominas);
            this.tabPanel1.Controls.Add(this.tabComercial);
            this.tabPanel1.Controls.Add(this.tabADD);
            this.tabPanel1.Controls.Add(this.tabResumen);
            this.tabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanel1.Location = new System.Drawing.Point(0, 24);
            this.tabPanel1.Name = "tabPanel1";
            this.tabPanel1.SelectedIndex = 0;
            this.tabPanel1.Size = new System.Drawing.Size(754, 561);
            this.tabPanel1.TabIndex = 3;
            this.tabPanel1.SelectedIndexChanged += new System.EventHandler(this.tabPanel1_SelectedIndexChanged);
            // 
            // tabContabilidad
            // 
            this.tabContabilidad.Controls.Add(this.panelContabilidad);
            this.tabContabilidad.Location = new System.Drawing.Point(4, 22);
            this.tabContabilidad.Name = "tabContabilidad";
            this.tabContabilidad.Padding = new System.Windows.Forms.Padding(3);
            this.tabContabilidad.Size = new System.Drawing.Size(746, 535);
            this.tabContabilidad.TabIndex = 0;
            this.tabContabilidad.Text = "Contabilidad";
            this.tabContabilidad.UseVisualStyleBackColor = true;
            // 
            // tabNominas
            // 
            this.tabNominas.Controls.Add(this.panelNominas);
            this.tabNominas.Location = new System.Drawing.Point(4, 22);
            this.tabNominas.Name = "tabNominas";
            this.tabNominas.Padding = new System.Windows.Forms.Padding(3);
            this.tabNominas.Size = new System.Drawing.Size(746, 535);
            this.tabNominas.TabIndex = 1;
            this.tabNominas.Text = "Nominas";
            this.tabNominas.UseVisualStyleBackColor = true;
            // 
            // tabComercial
            // 
            this.tabComercial.Controls.Add(this.panelComercial);
            this.tabComercial.Location = new System.Drawing.Point(4, 22);
            this.tabComercial.Name = "tabComercial";
            this.tabComercial.Padding = new System.Windows.Forms.Padding(3);
            this.tabComercial.Size = new System.Drawing.Size(746, 535);
            this.tabComercial.TabIndex = 2;
            this.tabComercial.Text = "Comercial";
            this.tabComercial.UseVisualStyleBackColor = true;
            // 
            // tabADD
            // 
            this.tabADD.Controls.Add(this.panelAdd);
            this.tabADD.Location = new System.Drawing.Point(4, 22);
            this.tabADD.Name = "tabADD";
            this.tabADD.Padding = new System.Windows.Forms.Padding(3);
            this.tabADD.Size = new System.Drawing.Size(746, 535);
            this.tabADD.TabIndex = 4;
            this.tabADD.Text = "ADD";
            this.tabADD.UseVisualStyleBackColor = true;
            // 
            // tabResumen
            // 
            this.tabResumen.Controls.Add(this.lbl_actionsQty);
            this.tabResumen.Controls.Add(this.dgv_actions);
            this.tabResumen.Controls.Add(this.btn_apply);
            this.tabResumen.Location = new System.Drawing.Point(4, 22);
            this.tabResumen.Name = "tabResumen";
            this.tabResumen.Padding = new System.Windows.Forms.Padding(3);
            this.tabResumen.Size = new System.Drawing.Size(746, 535);
            this.tabResumen.TabIndex = 3;
            this.tabResumen.Text = "Resumen";
            this.tabResumen.UseVisualStyleBackColor = true;
            // 
            // btn_apply
            // 
            this.btn_apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_apply.Location = new System.Drawing.Point(644, 506);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(94, 23);
            this.btn_apply.TabIndex = 1;
            this.btn_apply.Text = "Aplicar";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // dgv_actions
            // 
            this.dgv_actions.AllowUserToAddRows = false;
            this.dgv_actions.AllowUserToDeleteRows = false;
            this.dgv_actions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_actions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_actions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empresa,
            this.Sistema,
            this.Accion,
            this.DB,
            this.ArchivoMDF,
            this.ArchivoLDF});
            this.dgv_actions.Location = new System.Drawing.Point(0, 0);
            this.dgv_actions.Name = "dgv_actions";
            this.dgv_actions.ReadOnly = true;
            this.dgv_actions.Size = new System.Drawing.Size(746, 500);
            this.dgv_actions.TabIndex = 2;
            // 
            // Empresa
            // 
            this.Empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Empresa.DataPropertyName = "Company";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Width = 73;
            // 
            // Sistema
            // 
            this.Sistema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sistema.DataPropertyName = "System";
            this.Sistema.HeaderText = "Sistema";
            this.Sistema.Name = "Sistema";
            this.Sistema.ReadOnly = true;
            this.Sistema.Width = 69;
            // 
            // Accion
            // 
            this.Accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Accion.DataPropertyName = "Action";
            this.Accion.HeaderText = "Acción";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Width = 65;
            // 
            // DB
            // 
            this.DB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DB.DataPropertyName = "DBName";
            this.DB.HeaderText = "DB";
            this.DB.Name = "DB";
            this.DB.ReadOnly = true;
            this.DB.Width = 47;
            // 
            // ArchivoMDF
            // 
            this.ArchivoMDF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ArchivoMDF.DataPropertyName = "FilenameMDF";
            this.ArchivoMDF.HeaderText = "Archivo MDF";
            this.ArchivoMDF.Name = "ArchivoMDF";
            this.ArchivoMDF.ReadOnly = true;
            this.ArchivoMDF.Width = 94;
            // 
            // ArchivoLDF
            // 
            this.ArchivoLDF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ArchivoLDF.DataPropertyName = "FilenameLDF";
            this.ArchivoLDF.HeaderText = "Archivo LDF";
            this.ArchivoLDF.Name = "ArchivoLDF";
            this.ArchivoLDF.ReadOnly = true;
            this.ArchivoLDF.Width = 91;
            // 
            // panelContabilidad
            // 
            this.panelContabilidad.Connection = null;
            this.panelContabilidad.ContpaqSystem = "Contabilidad";
            this.panelContabilidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContabilidad.Location = new System.Drawing.Point(3, 3);
            this.panelContabilidad.Name = "panelContabilidad";
            this.panelContabilidad.Size = new System.Drawing.Size(740, 529);
            this.panelContabilidad.TabIndex = 0;
            // 
            // panelNominas
            // 
            this.panelNominas.Connection = null;
            this.panelNominas.ContpaqSystem = "Nóminas";
            this.panelNominas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNominas.Location = new System.Drawing.Point(3, 3);
            this.panelNominas.Name = "panelNominas";
            this.panelNominas.Size = new System.Drawing.Size(740, 529);
            this.panelNominas.TabIndex = 1;
            // 
            // panelComercial
            // 
            this.panelComercial.Connection = null;
            this.panelComercial.ContpaqSystem = "Comercial";
            this.panelComercial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelComercial.Location = new System.Drawing.Point(3, 3);
            this.panelComercial.Name = "panelComercial";
            this.panelComercial.Size = new System.Drawing.Size(740, 529);
            this.panelComercial.TabIndex = 1;
            // 
            // panelAdd
            // 
            this.panelAdd.Connection = null;
            this.panelAdd.ContpaqSystem = "Administrador de Documentos Digitales";
            this.panelAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdd.Location = new System.Drawing.Point(3, 3);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(740, 529);
            this.panelAdd.TabIndex = 0;
            // 
            // lbl_actionsQty
            // 
            this.lbl_actionsQty.AutoSize = true;
            this.lbl_actionsQty.Location = new System.Drawing.Point(487, 511);
            this.lbl_actionsQty.Name = "lbl_actionsQty";
            this.lbl_actionsQty.Size = new System.Drawing.Size(111, 13);
            this.lbl_actionsQty.TabIndex = 3;
            this.lbl_actionsQty.Text = "Cantidad de Acciones";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 607);
            this.Controls.Add(this.tabPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPanel1.ResumeLayout(false);
            this.tabContabilidad.ResumeLayout(false);
            this.tabNominas.ResumeLayout(false);
            this.tabComercial.ResumeLayout(false);
            this.tabADD.ResumeLayout(false);
            this.tabResumen.ResumeLayout(false);
            this.tabResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_actions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status;
        private System.Windows.Forms.TabControl tabPanel1;
        private System.Windows.Forms.TabPage tabContabilidad;
        private Components.SystemPanel panelContabilidad;
        private System.Windows.Forms.TabPage tabNominas;
        private Components.SystemPanel panelNominas;
        private System.Windows.Forms.TabPage tabComercial;
        private Components.SystemPanel panelComercial;
        private System.Windows.Forms.ToolStripMenuItem recargarToolStripMenuItem;
        private System.Windows.Forms.TabPage tabResumen;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.TabPage tabADD;
        private Components.AddPanel panelAdd;
        private System.Windows.Forms.DataGridView dgv_actions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArchivoMDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArchivoLDF;
        private System.Windows.Forms.Label lbl_actionsQty;
    }
}

