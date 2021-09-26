using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaModelo
{
    public class OtorgarPermisos
    {
        Conexion cn = new Conexion();
        //Funcion para obtener el codigo del usuario
        public string funcObtenerCodigoUsuario(string usuarioLogin)
        {
            string strCodigo = "";
            try
            {
                OdbcCommand command = new OdbcCommand("select LO.pkId from Usuario LO where LO.nombre ='" + usuarioLogin + "';", cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
                strCodigo = reader.GetString(0);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("CapaModelo Error al consular obtenerCodigoUsuario:  " + ex);
            }
            return strCodigo;
        }

        //funcion para obtener los permisos por aplicacion del usuario.
        public string funcPermisosPorAplicacion(string strUsuario)
        {
            string strCodigo = funcObtenerCodigoUsuario(strUsuario);
            string strPermisosAplicacion = "";
            try
            {
                OdbcCommand command = new OdbcCommand("SELECT permisoEscritura, permisoLectura,permisoModificar, permisoEliminar, permisoImprimir FROM UsuarioAplicacion WHERE fkIdUsuario = " + strCodigo, cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
                strPermisosAplicacion = reader.GetString(0) + "," + reader.GetString(1) + "," + reader.GetString(2) + "," + reader.GetString(3) + "," + reader.GetString(4);
                reader.Close();
                return strPermisosAplicacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CapaModelo Error al consular PermisosPorAplicacion:  " + ex);
                return null;

            }

        }


    }
}
