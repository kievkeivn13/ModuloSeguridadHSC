using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;

namespace CapaVista
{
    public partial class frmRecuperarContraseña : Form
    {
        Controlador conAplicacion = new Controlador();
        //string Usuario = "";
        public frmRecuperarContraseña()
        {
            InitializeComponent();
            llenarcbxUsuario();
            CenterToScreen();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                Encriptar encriptar = new Encriptar();
                Controlador controladorPerfil = new Controlador();
                if (txtConfirmacion.Text != null && txtContraseña.Text != null && cbxUsuario.SelectedIndex!=-1 || cbxUsuario.SelectedIndex != 0)
                {

                    if (txtContraseña.Text != txtConfirmacion.Text)
                    {
                        MessageBox.Show("La contraseña no es igual.");
                        funLimpiar();
                    }
                    else
                    {
                        //conAplicacion.recuperarContraseña( cbxUsuario.SelectedIndex.ToString(),txtConfirmacion.Text.Trim());
                        string password = encriptar.funcEncryptString(key, txtConfirmacion.Text.Trim());
                        conAplicacion.recuperarContraseña(cbxUsuario.SelectedIndex.ToString(), password);

                        MessageBox.Show("Modificación Realizada");
                        funLimpiar();
                    }
                }  else
                {
                    MessageBox.Show("Una o más casillas vacías.");
                }         

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }
        public void llenarcbxUsuario()
        {
            try
            {
                cbxUsuario.Items.Clear();
                OdbcDataReader datareader = conAplicacion.llenarcbo();
                cbxUsuario.Items.Add("Selecione un Usuario");
                while (datareader.Read())
                {
                    cbxUsuario.Items.Add(datareader[0].ToString());
                }
                cbxUsuario.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex); }
        }


        public void funLimpiar()
        {
            txtContraseña.Text = "";
            txtConfirmacion.Text = "";
           
            cbxUsuario.SelectedIndex = 0;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            funLimpiar();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = false;
            btnPassword.Visible = false;
            btnPasswordn.Visible = true;
        }
        private void btnPasswordN_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
            btnPassword.Visible = true;
            btnPasswordn.Visible = false;
        }

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            txtConfirmacion.UseSystemPasswordChar = false;
            btnConfirmacion.Visible = false;
            btnConfirmacionN.Visible = true;
            
        }
        private void btnConfirmacionN_Click(object sender, EventArgs e)
        {
            txtConfirmacion.UseSystemPasswordChar = true;
            btnConfirmacion.Visible = true;
            btnConfirmacionN.Visible = false;
        }
    }
}
