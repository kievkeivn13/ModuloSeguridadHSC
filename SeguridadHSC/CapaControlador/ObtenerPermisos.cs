﻿using CapaModeloSeguridadHSC;

namespace CapaControladorSeguridadHSC
{ 
    public class ObtenerPermisos
    { static string Usuario;
        PermisosAplicacion permisos = new PermisosAplicacion();
        public string funcPermisosPorAplicacion(string strUsuario)
        {
            return permisos.funcPermisosPorAplicacion(strUsuario);
        }
        public string usuarioglobal
        {
            get { return Usuario; }
            set { Usuario = value; }
        }



    }



   
   
}
