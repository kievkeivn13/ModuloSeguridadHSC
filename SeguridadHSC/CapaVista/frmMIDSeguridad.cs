using System;
using System.Windows.Forms;
using CapaControladorSeguridadHSC;

namespace CapaVistaSeguridadHSC
{
    public partial class frmMIDSeguridad : Form
    {
        ObtenerPermisos global = new ObtenerPermisos();
        RecorrerAplicacion recorrer = new RecorrerAplicacion();
        public string modulo = "1";
        public string id;
        public int valor;
        public frmMIDSeguridad()
        {
            InitializeComponent();
            CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLoginHSC form = new frmLoginHSC();
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtUsuario.Text = form.usuario();
            }
            /*this.Hide();
            var form2 = new frmLoginHSC();
            form2.Closed += (s, args) => this.Hide();
            form2.Show();*/
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //nombreform form3 = new nombreform();
            //form3.MdiParent = this.MdiParent;

            //form3.Show();
        }

        private void btnAplicacion_Click(object sender, EventArgs e)
        {
           id = "0003";
            int validar = 0;
            valor = recorrer.comprobar(modulo, txtIdUsuario.Text,id,validar);
            if (valor != 0)
            {
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
            }
            MessageBox.Show(valor.ToString());
            frmMantenimientoAplicacion form3 = new frmMantenimientoAplicacion();
            form3.MdiParent = this;

            form3.Show();
        }

        private void btnModulos_Click(object sender, EventArgs e)
        {
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            id = "0002";
            int validar = 0;
            valor = recorrer.comprobar(modulo, txtIdUsuario.Text, id, validar);
            if (valor != 0)
            {
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
            }
            MessageBox.Show(valor.ToString());
            frmMantenimientoPerfil form3 = new frmMantenimientoPerfil();
            form3.MdiParent = this;

            form3.Show();
        }

        private void btnAsignacionDeAplicacionAUsuarios_Click(object sender, EventArgs e)
        {
            id = "0008";
            int validar = 0;
            valor = recorrer.comprobar(modulo, txtIdUsuario.Text, id, validar);
            if (valor != 0)
            {
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
            }
            MessageBox.Show(valor.ToString());
            frmAplicaciones form3 = new frmAplicaciones();
            form3.MdiParent = this;

            form3.Show();
        }

        private void btnAsignacionDeAplicacionesAPerfiles_Click(object sender, EventArgs e)
        {
            id = "0006";
            frmAplicacionesPerfiles form3 = new frmAplicacionesPerfiles();
            form3.MdiParent = this;

            form3.Show();
        }

        private void btnCambioContraseña_Click(object sender, EventArgs e)
        {
            id = "0004";
            frmCambioContraseña form3 = new frmCambioContraseña();
            form3.MdiParent = this;

            form3.Show();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
        }

        private void btnAsiginaciónDePerfilesAUsuarios_Click(object sender, EventArgs e)
        {
            id = "0007";
            frmPerfiles form3 = new frmPerfiles();
            form3.MdiParent = this;

            form3.Show();
        }

        private void bitácoraDeLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = "0010";

            frmBitacora form3 = new frmBitacora();
            form3.MdiParent = this;

            form3.Show();
        }

        private void registrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = "0002";
            frmRegistrarUsuario form3 = new frmRegistrarUsuario();
            form3.MdiParent = this;

            form3.Show();
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            id = "000";
            frmPermisos form3 = new frmPermisos();
            form3.MdiParent = this;

            form3.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmLoginHSC_Load(object sender, EventArgs e)
        {
            frmLoginHSC form = new frmLoginHSC();
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtUsuario.Text = form.usuario();
                global.usuarioglobal = txtUsuario.Text;
                txtIdUsuario.Text = form.obtenerIdUsuario;
            }
            else
            {
                this.Close();
            }

        }
    }
}