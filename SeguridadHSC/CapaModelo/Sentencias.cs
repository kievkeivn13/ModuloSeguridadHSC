using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Sentencias
    {


        Conexion cn = new Conexion();
        OdbcCommand Comm;
        //frmLogin
        public int funIniciarSesion(string Usuario, string Contraseña, int validar)
        {
            try
            {
                string con = "";

                string Query = "select * from `componenteseguridad`.`Usuario` where nombre='" + Usuario + "';";

                OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    con = busqueda["contraseña"].ToString();
                }

                validar = Contraseña.CompareTo(con);


            }
            catch
            {

            }

            return validar;


        }


        //frmMantenimientoAplicacion
        public void funInsertar(string Id, string Nombre, int estado, string ruta)
        {

            string cadena = "INSERT INTO" +
            " `componenteseguridad`.`Aplicacion` VALUES (" + "'" + Id + "', '" + Nombre + "' , " + estado + ", '" + ruta + "');";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();


        }


        public void funModificar(string Id, string Nombre, int estado, string ruta)
        {

            string cadena = "UPDATE componenteseguridad.aplicacion set pkId ='" + Id
              + "',nombre ='" + Nombre + "',estado = " + estado + ", idReporteAsociado = '" + ruta + "'  where pkId= '" + Id + "';";


            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();




        }

        public void funEliminar(string Id)
        {

            string cadena = "delete from componenteseguridad.aplicacion where pkId ='" + Id + "';";


            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

        }




        public (string, int) funBuscar(string id, string nombre, int estado, string ruta)
        {


            string Query = "select * from `componenteseguridad`.`Aplicacion` where pkId='" + id + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                nombre = busqueda["nombre"].ToString();
                estado = int.Parse(busqueda["estado"].ToString());

            }


            return (nombre, estado);


        }

        //frmPerfiles

        public OdbcDataAdapter PerfilllenarTbl(string tabla2)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT pkid, nombre FROM " + tabla2 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter PerfilllenarTblPersonal(string tabla2, string condicion)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT perfil.pkid, perfil.nombre FROM " + tabla2 + "  LEFT JOIN usuarioperfil ON perfil.pkid = usuarioperfil.fkidperfil LEFT JOIN usuario ON usuarioperfil.fkidusuario = usuario.pkid WHERE usuario.pkid = " + condicion + " ORDER BY perfil.pkid;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter PerfilllenarNombre(string tabla, string condicion)// metodo  que obtinene el contenido
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT nombre FROM " + tabla + " WHERE pkid = " + condicion + "  ;";
            OdbcDataAdapter dataName = new OdbcDataAdapter(sql, cn.conexion());
            return dataName;
        }

        public void Perfilagregar(string tabla3, string valor1, string valor2)
        {
            string sql = "INSERT INTO " + tabla3 + " (fkidUsuario, fkidPerfil) Values( '" + valor1 + "', '" + valor2 + "');";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void Perfileliminar(string tabla3, string valor1, string valor2)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "' AND  fkidperfil='" + valor2 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void Perfileliminartodo(string tabla3, string valor1)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void Perfilagregartodo(string tabla3, string valor1, string valor2, string tabla2)
        {
            string sql = "INSERT INTO usuarioperfil (fkidUsuario, fkidPerfil) SELECT NULL, pkid FROM perfil;";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            string sql2 = "UPDATE usuarioperfil SET " + tabla3 + " = '" + valor1 + "' WHERE fkidUsuario = '';";
            OdbcCommand consulta2 = new OdbcCommand(sql2, cn.conexion());
            consulta2.ExecuteNonQuery();
        }

        //frmAplicaciones
        public OdbcDataAdapter aplicacionllenarTbl(string tabla2)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT pkid, nombre FROM " + tabla2 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter aplicacionllenarTblPerfil(string tabla4)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT pkid, nombre FROM " + tabla4 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter aplicacionllenarTblPersonal(string tabla2, string condicion)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT aplicacion.pkid, aplicacion.nombre FROM " + tabla2 + "  LEFT JOIN UsuarioAplicacionAsignados ON aplicacion.pkid = UsuarioAplicacionAsignados.fkidaplicacion LEFT JOIN usuario ON UsuarioAplicacionAsignados.fkidusuario = usuario.pkid WHERE usuario.pkid = " + condicion + " ORDER BY aplicacion.pkid;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter aplicacionllenarNombre(string tabla, string condicion)// metodo  que obtinene el contenido
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT nombre FROM " + tabla + " WHERE pkid = " + condicion + "  ;";
            OdbcDataAdapter dataName = new OdbcDataAdapter(sql, cn.conexion());
            return dataName;
        }

        public void aplicacionagregar(string tabla3, string valor1, string valor2)
        {
            string sql = "INSERT INTO " + tabla3 + " (fkidUsuario, fkidaplicacion) Values( '" + valor1 + "', '" + valor2 + "');";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void aplicacioneliminar(string tabla3, string valor1, string valor2)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "' AND  fkidaplicacion='" + valor2 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void aplicacioneliminartodo(string tabla3, string valor1)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void aplicacionagregartodo(string tabla3, string valor1, string valor2, string tabla2)
        {
            string sql = "INSERT INTO UsuarioAplicacionAsignados (fkidUsuario, fkidaplicacion) SELECT NULL, pkid FROM aplicacion;";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            string sql2 = "UPDATE UsuarioAplicacionAsignados SET " + tabla3 + " = '" + valor1 + "' WHERE fkidUsuario = '';";
            OdbcCommand consulta2 = new OdbcCommand(sql2, cn.conexion());
            consulta2.ExecuteNonQuery();
        }

        //frmRecuperarContraseña
        public OdbcDataReader funcModificarContraseña(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo-modificar ", Error);
                return null;
            }
        }
        public void funRecuperar(string Usuario, string Contraseña)
        {
            try
            {
                string cadena = "UPDATE" +
                " `componenteseguridad`.`Usuario` SET contraseña=" + Contraseña + "WHERE nombre=" + Usuario + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo-modificar ", Error);
            }
        }

        public OdbcDataReader llenarcbxUsuario(string sql)
        {
            try
            {
                OdbcCommand datos = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        //mantenimiento Perfil

        public void funInsertar(string Id, string Nombre, int estado)
        {

            string cadena = "INSERT INTO" +
            " `componenteseguridad`.`Perfil` VALUES (" + "'" + Id + "', '" + Nombre + "' , " + estado + ");";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();


        }


        public void funModificar(string Id, string Nombre, int estado)
        {

            string cadena = "UPDATE componenteseguridad.perfil set pkId ='" + Id
              + "',nombre ='" + Nombre + "',estado = " + estado + "  where pkId= '" + Id + "';";


            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();




        }

        public void funEliminarPerfil(string Id)
        {

            string cadena = "delete from componenteseguridad.perfil where pkId ='" + Id + "';";


            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

        }




        public (string, int) funBuscar(string id, string nombre, int estado)
        {


            string Query = "select * from `componenteseguridad`.`Perfil` where pkId='" + id + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                nombre = busqueda["nombre"].ToString();
                estado = int.Parse(busqueda["estado"].ToString());

            }


            return (nombre, estado);
        }


        //Aplicacion a perfiles

        public OdbcDataAdapter llenarTblappaperf(string tabla2)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT pkid, nombre FROM " + tabla2 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter llenarTblPersonalappaperf(string tabla2, string condicion)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT aplicacion.pkid, aplicacion.nombre FROM " + tabla2 + "  LEFT JOIN aplicacionperfil ON aplicacion.pkid = aplicacionperfil.fkidAplicacion LEFT JOIN perfil ON aplicacionperfil.fkidPerfil = perfil.pkid WHERE perfil.pkid = " + condicion + " ORDER BY aplicacion.pkid;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter llenarNombreappaperf(string tabla, string condicion)// metodo  que obtinene el contenido
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT nombre FROM " + tabla + " WHERE pkid = " + condicion + "  ;";
            OdbcDataAdapter dataName = new OdbcDataAdapter(sql, cn.conexion());
            return dataName;
        }
        public void agregarappaperf(string tabla3, string valor1, string valor2)
        {
            string sql = "INSERT INTO " + tabla3 + " (fkIdPerfil, fkIdAplicacion) Values( '" + valor1 + "', '" + valor2 + "');";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }
        public void eliminarappaperf(string tabla3, string valor1, string valor2)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidPerfil = '" + valor1 + "' AND  fkidAplicacion='" + valor2 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void perfileliminartodoappaperf(string tabla3, string valor1)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidPerfil = '" + valor1 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void perfilagregartodoappaperf(string tabla3, string valor1, string valor2, string tabla2)
        {
            string sql = "INSERT INTO usuarioperfil (fkidAplicacion, fkidPerfil) SELECT NULL, pkid FROM perfil;";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            string sql2 = "UPDATE aplicacionperfil SET " + tabla3 + " = '" + valor1 + "' WHERE fkidUsuario = '';";
            OdbcCommand consulta2 = new OdbcCommand(sql2, cn.conexion());
            consulta2.ExecuteNonQuery();
        }

        //Cambiar contraseña

        public OdbcDataReader funcModificar(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo-modificar ", Error);
                return null;
            }
        }

    }
}
