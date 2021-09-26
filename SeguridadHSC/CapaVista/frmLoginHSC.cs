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
using System.Windows.Input;
using System.Windows;
using BitacoraUsuario;

namespace CapaVista
{
    public partial class frmLoginHSC : Form
    {
        private Controlador conAplicacion = new Controlador();

        public frmLoginHSC()
        {
            InitializeComponent();

            txtUsuario.Focus();
            CenterToScreen();
        }

        private string nombreUsuario = "";

        public string obtenerNombreUsuario()
        {
            nombreUsuario = txtUsuario.Text;
            return nombreUsuario;
        }

        private void frmLoginHSC_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            funValidarClave();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            funValidarUsuario();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            int validar = 0;
            string Usuario = txtUsuario.Text.Trim();
            string Contraseña = txtClave.Text.Trim();
            validar = conAplicacion.InicarSesion(Usuario, Contraseña, validar);

            if (txtUsuario.Text != "")
            {
                if (validar != 0)
                {
                    MessageBox.Show("Error 305: " + "Usuario o contraseña incorrectos. ");
                    funLimpiar();
                }
                else
                {
                    //llamada a la forma
                    BitacoraLoginUsuario loggear = new BitacoraLoginUsuario();
                    string id = loggear.obtenerIdDeUsuario(Usuario);
                    loggear.guardarLoginUsuario(id, "1");
                    MessageBox.Show(" Bienvenido " + Usuario);
                    funLimpiar();
                    this.Hide();
                    var form2 = new frmMIDSeguridad();
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar su usuario ");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = false;
            btnPassword.Visible = false;
            btnPasswordn.Visible = true;
        }

        private void btnPasswordn_Click(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = true;
            btnPassword.Visible = true;
            btnPasswordn.Visible = false;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            //mostrara ayuda
            //Help.ShowHelp(this, "mostrara ayuda");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        public void funLimpiar()
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
            lblClave.Text = "";
            lblUsuario.Text = "";
            adClave.Visible = false;
            adUser.Visible = false;
        }

        public void funValidarUsuario()
        {
            if (txtUsuario.Text.Trim() != "")
            {
                lblUsuario.Text = "";
                adUser.Visible = false;
            }
            else
            {
                lblUsuario.Text = "Debe ingresar usuario.";
                adUser.Visible = true;
            }
        }

        public void funValidarClave()
        {
            if (txtClave.Text.Trim() != "")
            {
                lblClave.Text = "";
                adClave.Visible = false;
            }
            else
            {
                lblClave.Text = "Debe ingresar contraseña.";
                adClave.Visible = true;
            }
        }

        private void txtUsuario_EnabledChanged(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
        }

        //Desplasamiento con botones
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;//elimina el sonido
                funValidarClave();
                btnIniciarSesion.Focus();//llama al evento click del boton
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;//elimina el sonido
                txtClave.Focus();
                funValidarUsuario();
            }
        }

        private void lkbRecuperarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            funLimpiar();
            this.Hide();
            var form2 = new frmRecuperarContraseña();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}