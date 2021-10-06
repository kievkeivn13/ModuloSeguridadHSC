using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;



namespace CapaVista
{
    public partial class frmMantenimientoAplicacion : Form
    {
        Controlador conAplicacion = new Controlador();
        public frmMantenimientoAplicacion()
        {
            InitializeComponent();
            CenterToScreen();
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

        private void frmMantenimientoAplicacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.aplicacion' Puede moverla o quitarla según sea necesario.
            //this.aplicacionTableAdapter1.Fill(this.dataSet1.aplicacion);
            // TODO: esta línea de código carga datos en la tabla 'componenteseguridadDataSet.aplicacion' Puede moverla o quitarla según sea necesario.
            try
            {
                this.aplicacionTableAdapter1.Fill(this.dataSet1.aplicacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            if(textBox3.Text == "1")
            {
                btnHabilitado.Checked = true;
            }
            else if ( textBox3.Text == "0")
            {
                btnInhabilitado.Checked = true;
            }
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
            actualizarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                conAplicacion.modificarAplicacion(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), " ");
                MessageBox.Show("Modificacion realizada");
                funLimpiar();
                actualizarTabla();
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
                actualizarTabla();
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


        public void actualizarTabla()
        {
            try
            {
                this.aplicacionTableAdapter1.Fill(this.dataSet1.aplicacion);
                //CapaVista.deporteTableAdapter.Fill(vista.vwDeportes.deporte);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            if (textBox3.Text == "1")
            {
                btnHabilitado.Checked = true;
            }
            else if (textBox3.Text == "0")
            {
                btnInhabilitado.Checked = true;
            }
        }
    }




}
