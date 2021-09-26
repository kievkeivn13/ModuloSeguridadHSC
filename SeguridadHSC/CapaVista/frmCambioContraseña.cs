using System;

using System.Windows.Forms;
using CapaControlador;


namespace CapaVista
{
    public partial class frmCambioContraseña : Form
    {
        string Usuario = "";
        public frmCambioContraseña()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            Encriptar encriptar = new Encriptar();
            Controlador controladorPerfil = new Controlador();
            if (txtNuevaContraseña.Text == "" || txtConfirmarContraseña.Text == "")
            {
                MessageBox.Show("Los Campos no Deben de Estar Vacios");
            }
            else
            {
                if (txtNuevaContraseña.Text == txtConfirmarContraseña.Text)
                {
                    string password = encriptar.funcEncryptString(key, txtConfirmarContraseña.Text);
                    controladorPerfil.funcModificar_Contraseña(Usuario, password);
                    MessageBox.Show("Contraseña Actualizada");
                    txtNuevaContraseña.Text = "";
                    txtConfirmarContraseña.Text = "";
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseñas No Coinciden");
                    txtNuevaContraseña.Text = "";
                    txtConfirmarContraseña.Text = "";
                }
            }
        }
    }
}
