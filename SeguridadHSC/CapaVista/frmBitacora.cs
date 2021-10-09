using System;
using System.Windows.Forms;

namespace CapaVistaSeguridadHSC
{
    public partial class frmBitacora : Form
    {
        public frmBitacora()
        {
            InitializeComponent();
        }

        private void btnActualizarBitacora_Click(object sender, EventArgs e)
        {
            dgvBitacora1.actualizarBitacora();
        }
    }
}