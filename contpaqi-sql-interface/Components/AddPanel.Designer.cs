namespace contpaqi_sql_interface.Components
{
    partial class AddPanel
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_attach = new System.Windows.Forms.Button();
            this.lbl_compStatus = new System.Windows.Forms.Label();
            this.lbl_system = new System.Windows.Forms.Label();
            this.dgv_databases = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chb_attach = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_databases)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_attach
            // 
            this.btn_attach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_attach.Location = new System.Drawing.Point(535, 3);
            this.btn_attach.Name = "btn_attach";
            this.btn_attach.Size = new System.Drawing.Size(127, 23);
            this.btn_attach.TabIndex = 2;
            this.btn_attach.Text = "Adjuntar index";
            this.btn_attach.UseVisualStyleBackColor = true;
            this.btn_attach.Click += new System.EventHandler(this.btn_attach_Click);
            // 
            // lbl_compStatus
            // 
            this.lbl_compStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_compStatus.Location = new System.Drawing.Point(215, 3);
            this.lbl_compStatus.Name = "lbl_compStatus";
            this.lbl_compStatus.Size = new System.Drawing.Size(314, 23);
            this.lbl_compStatus.TabIndex = 3;
            this.lbl_compStatus.Text = "Index no adjunto";
            this.lbl_compStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_system
            // 
            this.lbl_system.AutoSize = true;
            this.lbl_system.Location = new System.Drawing.Point(3, 8);
            this.lbl_system.Name = "lbl_system";
            this.lbl_system.Size = new System.Drawing.Size(70, 13);
            this.lbl_system.TabIndex = 6;
            this.lbl_system.Text = "Desconocido";
            // 
            // dgv_databases
            // 
            this.dgv_databases.AllowUserToAddRows = false;
            this.dgv_databases.AllowUserToDeleteRows = false;
            this.dgv_databases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_databases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_databases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.GUID,
            this.Contabilidad,
            this.Nominas,
            this.Comercial});
            this.dgv_databases.Location = new System.Drawing.Point(3, 55);
            this.dgv_databases.MultiSelect = false;
            this.dgv_databases.Name = "dgv_databases";
            this.dgv_databases.ReadOnly = true;
            this.dgv_databases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_databases.Size = new System.Drawing.Size(659, 452);
            this.dgv_databases.TabIndex = 7;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // GUID
            // 
            this.GUID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GUID.DataPropertyName = "GUID";
            this.GUID.HeaderText = "GUID";
            this.GUID.Name = "GUID";
            this.GUID.ReadOnly = true;
            this.GUID.Width = 59;
            // 
            // Contabilidad
            // 
            this.Contabilidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Contabilidad.DataPropertyName = "GUIDContabilidad";
            this.Contabilidad.HeaderText = "Contabilidad";
            this.Contabilidad.Name = "Contabilidad";
            this.Contabilidad.ReadOnly = true;
            this.Contabilidad.Width = 90;
            // 
            // Nominas
            // 
            this.Nominas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nominas.DataPropertyName = "GUIDNominas";
            this.Nominas.HeaderText = "Nominas";
            this.Nominas.Name = "Nominas";
            this.Nominas.ReadOnly = true;
            this.Nominas.Width = 73;
            // 
            // Comercial
            // 
            this.Comercial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Comercial.DataPropertyName = "GUIDComercial";
            this.Comercial.HeaderText = "Comercial";
            this.Comercial.Name = "Comercial";
            this.Comercial.ReadOnly = true;
            this.Comercial.Width = 78;
            // 
            // chb_attach
            // 
            this.chb_attach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_attach.AutoSize = true;
            this.chb_attach.Location = new System.Drawing.Point(571, 32);
            this.chb_attach.Name = "chb_attach";
            this.chb_attach.Size = new System.Drawing.Size(91, 17);
            this.chb_attach.TabIndex = 8;
            this.chb_attach.Text = "Adjuntar ADD";
            this.chb_attach.UseVisualStyleBackColor = true;
            this.chb_attach.CheckedChanged += new System.EventHandler(this.chb_attach_CheckedChanged);
            // 
            // AddPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chb_attach);
            this.Controls.Add(this.dgv_databases);
            this.Controls.Add(this.lbl_system);
            this.Controls.Add(this.lbl_compStatus);
            this.Controls.Add(this.btn_attach);
            this.Name = "AddPanel";
            this.Size = new System.Drawing.Size(665, 529);
            this.Load += new System.EventHandler(this.AddPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_databases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_attach;
        private System.Windows.Forms.Label lbl_compStatus;
        private System.Windows.Forms.Label lbl_system;
        private System.Windows.Forms.DataGridView dgv_databases;
        private System.Windows.Forms.CheckBox chb_attach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contabilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comercial;
    }
}
