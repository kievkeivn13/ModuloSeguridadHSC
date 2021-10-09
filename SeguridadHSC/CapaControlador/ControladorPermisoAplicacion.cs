using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModeloSeguridadHSC;
using System.Data;
using System.Data.Odbc;

namespace CapaControladorSeguridadHSC
{
    //funcion Ashly Barrios
     public class ControladorPermisoAplicacion
    {
        private PermisosAplicacion sn = new PermisosAplicacion();
        public int habilitarApp(string modulo, string usuario,string aplicacion,int validar)
        {
             validar= sn.funHabilitarAp(modulo, usuario,aplicacion,validar);
            return validar;
        }

        public string funObtenerCod(string Usuario, string Contrasena)
        {
            string id = sn.funObtenerCodigo(Usuario, Contrasena);
            return id;
        }
    }
}
