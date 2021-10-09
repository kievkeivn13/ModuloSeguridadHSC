﻿using CapaControladorSeguridadHSC;
using System;
using System.Windows.Forms;

namespace CapaVistaSeguridadHSC
{
    public partial class frmRegistrarUsuario : Form
    {
        public frmRegistrarUsuario()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Controlador s = new Controlador();
            Encriptar a = new Encriptar();
            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            string hash = a.funcEncryptString(key, txtContraseña.Text);
            s.registrarUsuario(txtIdUsuario.Text, txtIdEmpleado.Text, txtUsuario.Text, hash, "1");
        }
    }
}