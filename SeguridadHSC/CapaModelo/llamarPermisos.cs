using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;


namespace CapaModeloSeguridadHSC
{
    public class llamarPermisos
    {
        Conexion cn = new Conexion();


        public string consulta1 = "";

        public void obteneraplicacion(string nombreapp, string idapp)
        {
            string Query = "SELECT pkid from aplicacion WHERE nombre='" + nombreapp + "';";
            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                idapp = busqueda["pkid"].ToString();

            }

        }




        public string llenarpermisos(string id, string p, string permiso, string tabla, string pk, string app)
        {


            string Query = "SELECT " + permiso + "  from  " + tabla + " WHERE " + pk + " = " + id + " AND fkIdAplicacion= " + app + ";";






            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();


            if (busqueda.Read())
            {

                if (permiso == "permisoEscritura")
                {
                    p = busqueda["permisoEscritura"].ToString();
                }
                else
                {
                    if (permiso == "permisoLectura")
                    {
                        p = busqueda["permisoLectura"].ToString();
                    }
                    else
                    {
                        if (permiso == "permisoImprimir")
                        {
                            p = busqueda["permisoImprimir"].ToString();
                        }

                        else
                        {
                            if (permiso == "permisoEliminar")
                            {
                                p = busqueda["permisoEliminar"].ToString();
                            }
                            else
                            {
                                if (permiso == "permisoModificar")
                                {
                                    p = busqueda["permisoModificar"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Error ");
                                }
                            }
                        }
                    }
                }

            }
            MessageBox.Show("QUERY:" + Query + " Resultado " + p);
            return p;

        }




    }
}