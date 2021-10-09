using CapaModeloSeguridadHSC;

namespace CapaControladorSeguridadHSC
{ 
    public class ObtenerPermisos
    { static string Usuario;
        PermisosAplicacion permisos = new PermisosAplicacion();
      
        public string usuarioglobal
        {
            get { return Usuario; }
            set { Usuario = value; }
        }



    }



   
   
}
