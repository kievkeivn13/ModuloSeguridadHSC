using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaControladorSeguridadHSC;
namespace CapaVistaSeguridadHSC
{
    //funcion habilitar aplicacion  Ashly Barrios
    public class RecorrerAplicacion
    {
        private ControladorPermisoAplicacion permisoApp = new ControladorPermisoAplicacion();
        public int comprobar(string modulo, string usuario,string aplicacion,int validar)
        {
            
            validar = permisoApp.habilitarApp(modulo, usuario, aplicacion,validar);
            return validar;

         
        }
    }
}
