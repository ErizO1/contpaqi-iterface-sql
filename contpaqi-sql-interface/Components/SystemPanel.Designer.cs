namespace contpaqi_sql_interface.Components
{
    partial class SystemPanel
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
            this.Adjuntar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_selectAll = new System.Windows.Forms.Button();
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
            this.Adjuntar,
            this.Empresa,
            this.Archivo});
            this.dgv_databases.Location = new System.Drawing.Point(3, 61);
            this.dgv_databases.MultiSelect = false;
            this.dgv_databases.Name = "dgv_databases";
            this.dgv_databases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_databases.Size = new System.Drawing.Size(659, 446);
            this.dgv_databases.TabIndex = 7;
            this.dgv_databases.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_databases_CellValueChanged);
            // 
            // Adjuntar
            // 
            this.Adjuntar.DataPropertyName = "Adjuntar";
            this.Adjuntar.HeaderText = "";
            this.Adjuntar.Name = "Adjuntar";
            this.Adjuntar.Width = 25;
            // 
            // Empresa
            // 
            this.Empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Empresa.DataPropertyName = "Empresa";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Width = 73;
            // 
            // Archivo
            // 
            this.Archivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Archivo.DataPropertyName = "Archivo";
            this.Archivo.HeaderText = "Nombre del archivo";
            this.Archivo.Name = "Archivo";
            this.Archivo.ReadOnly = true;
            this.Archivo.Width = 114;
            // 
            // btn_selectAll
            // 
            this.btn_selectAll.Location = new System.Drawing.Point(535, 32);
            this.btn_selectAll.Name = "btn_selectAll";
            this.btn_selectAll.Size = new System.Drawing.Size(127, 23);
            this.btn_selectAll.TabIndex = 8;
            this.btn_selectAll.Text = "Seleccionar todos";
            this.btn_selectAll.UseVisualStyleBackColor = true;
            this.btn_selectAll.Click += new System.EventHandler(this.btn_selectAll_Click);
            // 
            // SystemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_selectAll);
            this.Controls.Add(this.dgv_databases);
            this.Controls.Add(this.lbl_system);
            this.Controls.Add(this.lbl_compStatus);
            this.Controls.Add(this.btn_attach);
            this.Name = "SystemPanel";
            this.Size = new System.Drawing.Size(665, 529);
            this.Load += new System.EventHandler(this.SystemPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_databases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_attach;
        private System.Windows.Forms.Label lbl_compStatus;
        private System.Windows.Forms.Label lbl_system;
        private System.Windows.Forms.DataGridView dgv_databases;
        private System.Windows.Forms.Button btn_selectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Adjuntar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Archivo;
    }
}
