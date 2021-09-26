namespace CapaVista
{
    partial class frmMantenimientoAplicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoAplicacion));
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gbxEstado = new System.Windows.Forms.GroupBox();
            this.btnInhabilitado = new System.Windows.Forms.RadioButton();
            this.btnHabilitado = new System.Windows.Forms.RadioButton();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelNombreaplicacion = new System.Windows.Forms.Label();
            this.labelIdaplicacion = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pkIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idReporteAsociadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aplicacionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new CapaVista.DataSet1();
            this.aplicacionTableAdapter1 = new CapaVista.DataSet1TableAdapters.aplicacionTableAdapter();
            this.gbxEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplicacionBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(349, 205);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(27, 20);
            this.textBox3.TabIndex = 22;
            this.textBox3.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(143, 111);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(212, 20);
            this.textBox2.TabIndex = 1;
            // 
            // gbxEstado
            // 
            this.gbxEstado.BackColor = System.Drawing.Color.Transparent;
            this.gbxEstado.Controls.Add(this.btnInhabilitado);
            this.gbxEstado.Controls.Add(this.btnHabilitado);
            this.gbxEstado.Location = new System.Drawing.Point(143, 164);
            this.gbxEstado.Name = "gbxEstado";
            this.gbxEstado.Size = new System.Drawing.Size(200, 100);
            this.gbxEstado.TabIndex = 20;
            this.gbxEstado.TabStop = false;
            this.gbxEstado.Text = "Estado Aplicacion";
            // 
            // btnInhabilitado
            // 
            this.btnInhabilitado.AutoSize = true;
            this.btnInhabilitado.Location = new System.Drawing.Point(115, 41);
            this.btnInhabilitado.Name = "btnInhabilitado";
            this.btnInhabilitado.Size = new System.Drawing.Size(79, 17);
            this.btnInhabilitado.TabIndex = 4;
            this.btnInhabilitado.TabStop = true;
            this.btnInhabilitado.Text = "Inhabilitado";
            this.btnInhabilitado.UseVisualStyleBackColor = true;
            this.btnInhabilitado.CheckedChanged += new System.EventHandler(this.btnInhabilitado_CheckedChanged);
            // 
            // btnHabilitado
            // 
            this.btnHabilitado.AutoSize = true;
            this.btnHabilitado.Location = new System.Drawing.Point(7, 41);
            this.btnHabilitado.Name = "btnHabilitado";
            this.btnHabilitado.Size = new System.Drawing.Size(72, 17);
            this.btnHabilitado.TabIndex = 3;
            this.btnHabilitado.TabStop = true;
            this.btnHabilitado.Text = "Habilitado";
            this.btnHabilitado.UseVisualStyleBackColor = true;
            this.btnHabilitado.CheckedChanged += new System.EventHandler(this.btnHabilitado_CheckedChanged);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(500, 48);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 10;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 0;
            // 
            // labelNombreaplicacion
            // 
            this.labelNombreaplicacion.AutoSize = true;
            this.labelNombreaplicacion.BackColor = System.Drawing.Color.Transparent;
            this.labelNombreaplicacion.Location = new System.Drawing.Point(38, 111);
            this.labelNombreaplicacion.Name = "labelNombreaplicacion";
            this.labelNombreaplicacion.Size = new System.Drawing.Size(99, 13);
            this.labelNombreaplicacion.TabIndex = 17;
            this.labelNombreaplicacion.Text = "Nombre Aplicación:";
            // 
            // labelIdaplicacion
            // 
            this.labelIdaplicacion.AutoSize = true;
            this.labelIdaplicacion.BackColor = System.Drawing.Color.Transparent;
            this.labelIdaplicacion.Location = new System.Drawing.Point(38, 73);
            this.labelIdaplicacion.Name = "labelIdaplicacion";
            this.labelIdaplicacion.Size = new System.Drawing.Size(73, 13);
            this.labelIdaplicacion.TabIndex = 16;
            this.labelIdaplicacion.Text = "ID Aplicación:";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(500, 77);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 24;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(500, 111);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(500, 140);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 26;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkIdDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.idReporteAsociadoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aplicacionBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(50, 294);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(525, 150);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick_1);
            // 
            // pkIdDataGridViewTextBoxColumn
            // 
            this.pkIdDataGridViewTextBoxColumn.DataPropertyName = "pkId";
            this.pkIdDataGridViewTextBoxColumn.HeaderText = "pkId";
            this.pkIdDataGridViewTextBoxColumn.Name = "pkIdDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            // 
            // idReporteAsociadoDataGridViewTextBoxColumn
            // 
            this.idReporteAsociadoDataGridViewTextBoxColumn.DataPropertyName = "idReporteAsociado";
            this.idReporteAsociadoDataGridViewTextBoxColumn.HeaderText = "idReporteAsociado";
            this.idReporteAsociadoDataGridViewTextBoxColumn.Name = "idReporteAsociadoDataGridViewTextBoxColumn";
            // 
            // aplicacionBindingSource1
            // 
            this.aplicacionBindingSource1.DataMember = "aplicacion";
            this.aplicacionBindingSource1.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aplicacionTableAdapter1
            // 
            this.aplicacionTableAdapter1.ClearBeforeFill = true;
            // 
            // frmMantenimientoAplicacion
            // 
            this.AcceptButton = this.btnInsertar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaVista.Properties.Resources._90_Simple_Backgrounds_Edit_and_Download_Visual_Learning_Center;
            this.ClientSize = new System.Drawing.Size(658, 491);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.gbxEstado);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelNombreaplicacion);
            this.Controls.Add(this.labelIdaplicacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMantenimientoAplicacion";
            this.Text = "frmMantenimientoAplicacion";
            this.Load += new System.EventHandler(this.frmMantenimientoAplicacion_Load);
            this.gbxEstado.ResumeLayout(false);
            this.gbxEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aplicacionBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox gbxEstado;
        private System.Windows.Forms.RadioButton btnInhabilitado;
        private System.Windows.Forms.RadioButton btnHabilitado;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelNombreaplicacion;
        private System.Windows.Forms.Label labelIdaplicacion;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource aplicacionBindingSource1;
        private DataSet1TableAdapters.aplicacionTableAdapter aplicacionTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReporteAsociadoDataGridViewTextBoxColumn;
    }
}