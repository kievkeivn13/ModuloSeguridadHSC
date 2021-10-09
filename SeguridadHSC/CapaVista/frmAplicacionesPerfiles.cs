using CapaControladorSeguridadHSC;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVistaSeguridadHSC
{
    public partial class frmAplicacionesPerfiles : Form
    {
        Controlador cn = new Controlador();
       public frmAplicacionesPerfiles()
        {
            InitializeComponent();
            CenterToScreen();

            aplicacionllenarTbl();
            actualizardatagriew();
            actualizardatagriewpersonal();
        }

        //Mostrar los datos CAPA VISTA
        string tabla = "usuario";
        string tabla2 = "aplicacion"; //aplicacion
        string tabla3 = "usuarioaplicacion"; //Usuario
        string tabla4 = "perfil";
        public void actualizardatagriew()
        {
            DataTable dt = cn.aplicacionllenarTbl(tabla2);
            dtgConsulta.DataSource = dt;
        }

        public void aplicacionllenarTbl()
        {
            DataTable dt = cn.aplicacionllenarTblPerfil(tabla4);
            dataGridView2.DataSource = dt;
        }

        public void actualizardatagriewpersonal()
        {
            DataTable dt = cn.aplicacionllenarTblPersonal(tabla2);
            dataGridView1.DataSource = dt;
        }




        private void button1_Click(object sender, EventArgs e)
        {

            aplicacionllenarTbl();
            actualizardatagriew();
            actualizardatagriewpersonal();

        }

        private void dtgConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dtgConsulta.CurrentRow.Cells[0].Value.ToString();
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fmConsulta_Load(object sender, EventArgs e)
        {

        }






        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dtgConsulta.CurrentRow.Cells[0].Value.ToString();



                textBox3.Text = dtgConsulta.CurrentRow.Cells[0].Value.ToString();
                textBox4.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                string valor1 = textBox4.Text;
                string valor2 = textBox3.Text;
                cn.aplicacionagregar(tabla3, valor1, valor2);
                actualizardatagriewpersonal();
                actualizardatagriewpersonal();
            }
            catch
            {

            }



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                string valor1 = textBox4.Text;
                string valor2 = textBox3.Text;
                cn.aplicacioneliminar(tabla3, valor1, valor2);
                actualizardatagriewpersonal();
                actualizardatagriewpersonal();

            }
            catch
            {

            }





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                cn.aplicacioneliminartodo(tabla3);
                actualizardatagriewpersonal();
            }
            catch
            {

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string valor1 = textBox1.Text;
            //string valor2 = textBox3.Text;
            //string condicion = textBox1.Text;
            //cn.aplicacioneliminartodo(tabla3, valor1);
            //cn.aplicacionagregartodo(tabla3, valor1, valor2, tabla2);


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Llenar con Enter

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;//elimina el sonido
                actualizardatagriewpersonal();
                actualizardatagriew();
                aplicacionllenarTbl();
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {

            textBox3.Text = "";
            dtgConsulta.DataSource = null;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }


        //Utilizar flechas para moverse entre botones

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;//elimina el sonido
                button3.Focus();//Mueve al siguiente boton
            }
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;//elimina el sonido
                button4.Focus();//Mueve al siguiente boton
            }
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;//elimina el sonido
                button2.Focus();//Mueve al siguiente boton
            }
        }
        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;//elimina el sonido
                button5.Focus();//Mueve al siguiente boton
            }
        }

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;//elimina el sonido
                button6.Focus();//Mueve al siguiente boton
            }
        }

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;//elimina el sonido

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;//elimina el sonido
            }
        }
    }
}
