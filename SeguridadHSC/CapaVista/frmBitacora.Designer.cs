
namespace CapaVistaSeguridadHSC
{
    partial class frmBitacora
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBitacora1 = new VistaBitacora.DGVBitacora();
            this.pkIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aplicacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conexionFechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conexionHoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizarBitacora = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvBitacora1);
            this.panel1.Location = new System.Drawing.Point(12, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 353);
            this.panel1.TabIndex = 0;
            // 
            // dgvBitacora1
            // 
            this.dgvBitacora1.AutoGenerateColumns = false;
            this.dgvBitacora1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBitacora1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvBitacora1.BackgroundColor = System.Drawing.Color.Wheat;
            this.dgvBitacora1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBitacora1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBitacora1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBitacora1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkIdDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn,
            this.hostDataGridViewTextBoxColumn,
            this.ipDataGridViewTextBoxColumn,
            this.moduloDataGridViewTextBoxColumn,
            this.aplicacionDataGridViewTextBoxColumn,
            this.accionDataGridViewTextBoxColumn,
            this.conexionFechaDataGridViewTextBoxColumn,
            this.conexionHoraDataGridViewTextBoxColumn});
            this.dgvBitacora1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvBitacora1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBitacora1.Location = new System.Drawing.Point(0, 0);
            this.dgvBitacora1.MultiSelect = false;
            this.dgvBitacora1.Name = "dgvBitacora1";
            this.dgvBitacora1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBitacora1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBitacora1.RowHeadersVisible = false;
            this.dgvBitacora1.Size = new System.Drawing.Size(821, 353);
            this.dgvBitacora1.TabIndex = 0;
            // 
            // pkIdDataGridViewTextBoxColumn
            // 
            this.pkIdDataGridViewTextBoxColumn.DataPropertyName = "pkId";
            this.pkIdDataGridViewTextBoxColumn.HeaderText = "pkId";
            this.pkIdDataGridViewTextBoxColumn.Name = "pkIdDataGridViewTextBoxColumn";
            this.pkIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "usuario";
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hostDataGridViewTextBoxColumn
            // 
            this.hostDataGridViewTextBoxColumn.DataPropertyName = "host";
            this.hostDataGridViewTextBoxColumn.HeaderText = "host";
            this.hostDataGridViewTextBoxColumn.Name = "hostDataGridViewTextBoxColumn";
            this.hostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ipDataGridViewTextBoxColumn
            // 
            this.ipDataGridViewTextBoxColumn.DataPropertyName = "ip";
            this.ipDataGridViewTextBoxColumn.HeaderText = "ip";
            this.ipDataGridViewTextBoxColumn.Name = "ipDataGridViewTextBoxColumn";
            this.ipDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // moduloDataGridViewTextBoxColumn
            // 
            this.moduloDataGridViewTextBoxColumn.DataPropertyName = "modulo";
            this.moduloDataGridViewTextBoxColumn.HeaderText = "modulo";
            this.moduloDataGridViewTextBoxColumn.Name = "moduloDataGridViewTextBoxColumn";
            this.moduloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aplicacionDataGridViewTextBoxColumn
            // 
            this.aplicacionDataGridViewTextBoxColumn.DataPropertyName = "aplicacion";
            this.aplicacionDataGridViewTextBoxColumn.HeaderText = "aplicacion";
            this.aplicacionDataGridViewTextBoxColumn.Name = "aplicacionDataGridViewTextBoxColumn";
            this.aplicacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accionDataGridViewTextBoxColumn
            // 
            this.accionDataGridViewTextBoxColumn.DataPropertyName = "accion";
            this.accionDataGridViewTextBoxColumn.HeaderText = "accion";
            this.accionDataGridViewTextBoxColumn.Name = "accionDataGridViewTextBoxColumn";
            this.accionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conexionFechaDataGridViewTextBoxColumn
            // 
            this.conexionFechaDataGridViewTextBoxColumn.DataPropertyName = "conexionFecha";
            this.conexionFechaDataGridViewTextBoxColumn.HeaderText = "conexionFecha";
            this.conexionFechaDataGridViewTextBoxColumn.Name = "conexionFechaDataGridViewTextBoxColumn";
            this.conexionFechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conexionHoraDataGridViewTextBoxColumn
            // 
            this.conexionHoraDataGridViewTextBoxColumn.DataPropertyName = "conexionHora";
            this.conexionHoraDataGridViewTextBoxColumn.HeaderText = "conexionHora";
            this.conexionHoraDataGridViewTextBoxColumn.Name = "conexionHoraDataGridViewTextBoxColumn";
            this.conexionHoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bitácora";
            // 
            // btnActualizarBitacora
            // 
            this.btnActualizarBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarBitacora.BackColor = System.Drawing.Color.White;
            this.btnActualizarBitacora.FlatAppearance.BorderSize = 0;
            this.btnActualizarBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizarBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarBitacora.Location = new System.Drawing.Point(740, 13);
            this.btnActualizarBitacora.Name = "btnActualizarBitacora";
            this.btnActualizarBitacora.Size = new System.Drawing.Size(93, 36);
            this.btnActualizarBitacora.TabIndex = 2;
            this.btnActualizarBitacora.Text = "Actualizar";
            this.btnActualizarBitacora.UseVisualStyleBackColor = false;
            this.btnActualizarBitacora.Click += new System.EventHandler(this.btnActualizarBitacora_Click);
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaVistaSeguridadHSC.Properties.Resources._90_Simple_Backgrounds_Edit_and_Download_Visual_Learning_Center;
            this.ClientSize = new System.Drawing.Size(845, 427);
            this.Controls.Add(this.btnActualizarBitacora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBitacora";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizarBitacora;
        private VistaBitacora.DGVBitacora dgvBitacora1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aplicacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conexionFechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conexionHoraDataGridViewTextBoxColumn;
    }
}