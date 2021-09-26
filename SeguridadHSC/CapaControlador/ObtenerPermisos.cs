using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaControlador
{
    public class ObtenerPermisos
    {
        OtorgarPermisos permisos = new OtorgarPermisos();
        public string funcPermisosPorAplicacion(string strUsuario)
        {
            return permisos.funcPermisosPorAplicacion(strUsuario);
        }
    }
}
