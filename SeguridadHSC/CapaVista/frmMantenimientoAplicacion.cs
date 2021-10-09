using CapaControladorSeguridadHSC;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;



namespace CapaVistaSeguridadHSC
{
    public partial class frmMantenimientoAplicacion : Form
    {
        Controlador conAplicacion = new Controlador();
        public frmMantenimientoAplicacion()
        {
            InitializeComponent();
            CenterToScreen();
            actualizardatagriew();
            llenarcbxAplicacion();

        }



        public void funLimpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            btnHabilitado.Checked = false;
            btnInhabilitado.Checked = false;
            textBox3.Text = "";

        }



        private void btnHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "1";
        }

        private void btnInhabilitado_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "0";
        }





        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                conAplicacion.insertarAplicacion(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), " ");
                MessageBox.Show("Insercion realizada");
                funLimpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Debes llenar todos los campos");
            }
            actualizardatagriew();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                conAplicacion.modificarAplicacion(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), " ");
                MessageBox.Show("Modificacion realizada");
                funLimpiar();
                actualizardatagriew();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Debes llenar todos los campos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                conAplicacion.eliminarAplicacion(textBox1.Text);
                MessageBox.Show("Eliminacion realizada");
                funLimpiar();
                actualizardatagriew();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No has ingresado Id del registro a eliminar");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            funLimpiar();
        }

        public void llenarcbxAplicacion()
        {
            try
            {
                cbxModulo.Items.Clear();
                OdbcDataReader datareader = conAplicacion.llenarcbxModulo();
                cbxModulo.Items.Add("Selecione un Modulo");
                while (datareader.Read())
                {
                    cbxModulo.Items.Add(datareader[0].ToString());
                }
                cbxModulo.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    textBox4.Text = fd.SelectedPath;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    textBox5.Text = fd.SelectedPath;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxModulo.SelectedValue.ToString() == null)
                {
                    textBox1.Text = "";
                }
                else
                {
                    textBox6.Text = cbxModulo.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        String tabla = "Aplicacion";

        public void actualizardatagriew()
        {
            DataTable dt = conAplicacion.llenarTblAplicacion(tabla);
            dataGridView1.DataSource = dt;

        }




    }




}
