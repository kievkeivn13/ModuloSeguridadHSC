using CapaControladorSeguridadHSC;
using System;
using System.Data;
using System.Windows.Forms;



namespace CapaVistaSeguridadHSC
{
    public partial class frmMantenimientoPerfil : Form
    {
        bloqueos b = new bloqueos();
        string idaplicacion = "204";
        string pe = "permisoEscritura";
        string pel = "permisoEliminar";
        string pm = "permisoModificar";
        string pl = "permisoLectura";
        string pi = "permisoImprimir";
        string t1 = "usuarioaplicacion";
        string t2 = "aplicacionperfil";
        string pk2 = "fkidperfil";
        string pk1 = "fkidusuario";
        string p1 = "";
        string p2 = "";
        string p3 = "";
        string p4 = "";
        string p5 = "";

        Controlador cn = new Controlador();
        public frmMantenimientoPerfil()
        {
            InitializeComponent();
            CenterToScreen();
            actualizardatagriew();
            obtenerpermisos("2", p1, pe, t2, pk2, idaplicacion);
            obtenerpermisos("2", p3, pm, t2, pk2, idaplicacion);
            obtenerpermisos("2", p4, pel, t2, pk2, idaplicacion);
            obtenerpermisos("2", p5, pi, t2, pk2, idaplicacion);
        }

        string tabla = "perfil";

        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(tabla);
            perfilTabla.DataSource = dt;
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

        private void frmMantenimientoPerfil_Load(object sender, EventArgs e)
        {

            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dataSet3.perfil' Puede moverla o quitarla según sea necesario.

            }
            catch (Exception Error)
            {
                Console.WriteLine("404", Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void perfilTabla_RowHeaderMouseClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
                {

                    cn.insertarPerfil(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
                    MessageBox.Show("Insercion realizada");
                    funLimpiar();
                }
                else
                {

                    MessageBox.Show("Error debe de ingresar todos los valores solicitados ");

                }
            }
            catch
            {
                MessageBox.Show("Error debe de ingresar todos los valores solicitados ");
            }
            actualizardatagriew();
        }




        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {

                cn.modificarPerfil(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
                MessageBox.Show("Insercion realizada");
                funLimpiar();
            }
            else
            {

                MessageBox.Show("Error debe de ingresar todos los valores solicitados ");

            }
            actualizardatagriew();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cn.eliminarPerfil(textBox1.Text);
            MessageBox.Show("Eliminacion realizada");
            funLimpiar();
            actualizardatagriew();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            funLimpiar();
        }


        public void actualizarTablaDeporte()
        {
            try
            {

                //CapaVista.deporteTableAdapter.Fill(vista.vwDeportes.deporte);
            }
            catch (Exception Error)
            {
                Console.WriteLine("404 ", Error);
            }

        }

        private void perfilTabla_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                textBox1.Text = perfilTabla.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = perfilTabla.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = perfilTabla.CurrentRow.Cells[2].Value.ToString();

                if (textBox3.Text == "1")
                {
                    btnHabilitado.Checked = true;
                }
                else if (textBox3.Text == "0")
                {
                    btnInhabilitado.Checked = true;
                }
            }
            catch
            {

            }
        }

        public void obtenerpermisos(string id, string p, string permiso, string t2, string pk, string app)
        {
            b.bloqueo(id, p, permiso, t2, pk, app);

            //label1.Text = permiso;
            //label2.Text = app;
            //label3.Text = pk;
            //label4.Text = p;

            if (permiso == pe)
            {

                if (p1 == "0")
                {

                    btnInsertar.Enabled = false;
                    //label1.Text = p1;
                }

                else
                {
                    if (p1 == "1")
                    {
                        btnInsertar.Enabled = true;
                        //label1.Text = p1;
                    }
                }
            }
            else
            {
                if (permiso == pm)
                {

                    if (p3 == "0")
                    {
                        btnModificar.Enabled = false;
                        //label2.Text = p3;
                    }
                    else
                    {
                        if (p3 == "1")
                        {
                            btnModificar.Enabled = true;
                            //label2.Text = p3;
                        }
                    }
                }
                else
                {
                    if (permiso == pel)
                    {
                        if (p4 == "0")
                        {
                            btnEliminar.Enabled = false;
                            //label3.Text = p4;
                        }
                        else
                        {
                            if (p4 == "1")
                            {
                                btnEliminar.Enabled = true;
                                //label3.Text = p4;
                            }
                        }
                    }
                    /* else
                     {
                         if (permiso == pi)
                         {
                             if (p5 == "0")
                             {
                                 btnImprimir.Enabled = false;
                             }
                             else
                             {
                                 if (p5 == "1")
                                 {
                                     btnImprimir.Enabled = true;
                                 }
                             }
                         }
                     }*/
                }
            }





        }


        /*   public void obteneraplicacion(string nombreapp,string idapp)
           {
               b.obteneraplicacion(nombreapp,idapp);
           }*/
    


    }





}
