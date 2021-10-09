using System;
using System.Data.Odbc;
using System.Windows.Forms;

namespace CapaModeloSeguridadHSC
{
    public class PermisosAplicacion
    {
        Conexion cn = new Conexion();
        private OdbcCommand Comm;
        //funcion habilitar aplicacion  Ashly Barrios
        public int funHabilitarAp(string idModulo, string idUsuario, string idApp, int validar)
        {

            try
            {
                string query = "SELECT fkIdAplicacion " +
                    "FROM aplicacion INNER JOIN usuarioaplicacion " +
                    "ON usuarioaplicacion.fkIdAplicacion = aplicacion.pkId where aplicacion.fkIdModulo = " + idModulo +
                    " and usuarioaplicacion.fkIdUsuario = " + idUsuario + ";";
                string idAp = "";
             
              
                Comm = new OdbcCommand(query, cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();

                MessageBox.Show(query);
             
                if (reader.Read())
                {
                    idAp = reader["fkIdAplicacion"].ToString();
                }
                MessageBox.Show(idAp);
                MessageBox.Show(idApp);
                validar = idApp.CompareTo(idAp);
                //validar = String.Compare(idAp, idApp, comparisonType: StringComparison.OrdinalIgnoreCase);


                MessageBox.Show(validar.ToString());
              
               

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consular usuario:  " + ex);
                return 1;
            }
            return validar;
        }

        public string funObtenerCodigo(string Usuario, string Contrasena)
        {
            try
            {

                string id = "";
                Comm = new OdbcCommand("SELECT * FROM componenteseguridad.usuario WHERE nombre ='" + Usuario + "' AND contraseña ='" + Contrasena + "' AND estado = 1 ;", cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                reader.Read();
                if (reader.Read())
                {

                    id = reader["pkId"].ToString();

                }


                return id;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consular codigo usuario:  " + ex);
                return null;
            }
        }

    }
}
