using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaControladorSeguridadHSC
{
    public class bloqueos
    {
        private Controlador cn = new Controlador();

        public string bloqueo(string id, string p, string permiso, string t2, string pk, string app)
        {
            cn.definirpermisosperfil(id, p, permiso, t2, pk, app);

            return p;

        }



        public void obteneraplicacion(string nombreapp, string idapp)
        {
            cn.obteneraplicacion(nombreapp, idapp);
        }


    }
}
