using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;




namespace CapaModelo
{
    public class Sentencias
    {
        private Conexion cn = new Conexion();
        private OdbcCommand Comm;

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

        public int funInicio(string Usuario, string Contrasena)
        {
            try
            {
                string Us = "";
                string Con = "";
                Comm = new OdbcCommand("SELECT nombre, contraseña FROM componenteseguridad.usuario WHERE nombre ='" + Usuario + "' AND contraseña ='" + Contrasena + "' AND estado = 1 ;", cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                reader.Read();
                Us = reader.GetString(0);
                Con = reader.GetString(1);
                reader.Close();
                if (String.IsNullOrEmpty(Us) || String.IsNullOrEmpty(Con))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consular usuario:  " + ex);
                return 0;
            }
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

        public OdbcDataAdapter llenarTblAplicacion(string tabla)// metodo  que obtinene el contenio de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
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
            string sql = "SELECT pkId, nombre FROM " + tabla2 + "  ;";
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

        public OdbcDataAdapter aplicacionllenarTblPersonal(string tabla3, string condicion)// metodo  que obtinene el contenido de una tabla
        {
            
                //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
                string sql = "SELECT aplicacion.pkid, aplicacion.nombre FROM " + tabla3 + "  LEFT JOIN usuarioaplicacion ON aplicacion.pkid = usuarioaplicacion.fkidAplicacion LEFT JOIN usuario ON usuarioaplicacion.fkIdUsuario = usuario.pkid WHERE usuario.pkid = " + condicion + " ORDER BY aplicacion.pkid;";
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
            string sql = "INSERT INTO " + tabla3 + "  Values('" +valor1+ "','" + valor2 + "',null,null,null,null,null);";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void aplicacioneliminar(string tabla3, string valor1, string valor2)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "' AND  fkidAplicacion='" + valor2 + "';";
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
            string sql = "INSERT INTO UsuarioAplicacion (fkidUsuario, fkidaplicacion) SELECT *, pkid FROM aplicacion;";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            string sql2 = "UPDATE UsuarioAplicacion SET " + tabla3 + " = '" + valor1 + "' WHERE fkidUsuario = '';";
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

        public OdbcDataAdapter llenarTbl(string tabla)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT pkid, nombre, estado FROM " + tabla + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
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

        public void registrarUsuario(string pkId, string fkIdEmpleado, string nombre, string contraseña, string estado)
        {
            string sql = "INSERT INTO usuario (pkId, fkIdEmpleado, nombre, contraseña, estado, intento) Values( '" + pkId + "', '" + fkIdEmpleado + "', '" + nombre + "', '" + contraseña + "', '" + estado + "', '0');";
            try
            {
                OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
                consulta.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ya existe un usuario con ese id de empleado");
            }
        }

        //frmPermisos
        public OdbcDataReader llenarcbxPerfil(string sql)
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

        public OdbcDataReader llenarcbxUsuarios(string sql)
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

        public OdbcDataReader llenarcbxAplicacion(string sql)
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

        public string consultaperfil(string nombre)
        {

            string id = "";
            string Query = "select * from `componenteseguridad`.`Perfil` where nombre='" + nombre + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                id = busqueda["pkid"].ToString();

            }


            return id;
        }

        public string consultausuario(string nombre)
        {

            string id = "";
            string Query = "select * from `componenteseguridad`.`Usuario` where nombre='" + nombre + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                id = busqueda["pkid"].ToString();

            }


            return id;
        }

        public string consultaaplicacion(string nombre)
        {

            string id = "";
            string Query = "select * from `componenteseguridad`.`Aplicacion` where nombre='" + nombre + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                id = busqueda["pkid"].ToString();

            }


            return id;
        }

        public void InsertarPUsuApl(string usuario, string aplicacion, int escribir, int leer, int modificar, int eliminar, int imprimir)
        {

            try
            {
                string cadena = "UPDATE usuarioaplicacion SET permisoEscritura=" + escribir + ",permisoLectura=" + leer + ",permisoModificar=" + modificar + ",permisoEliminar=" + eliminar + ",permisoImprimir=" + imprimir + " WHERE fkIdUsuario=" + usuario + " AND fkIdAplicacion=" + aplicacion + ";";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Asignación Exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Asignación:" + ex);
            }


        }

        public void InsertarPPerApl(string perfil, string aplicacion, int escribir, int leer, int modificar, int eliminar, int imprimir)
        {

            try
            {
                string cadena = "UPDATE aplicacionperfil SET permisoEscritura=" + escribir + ",permisoLectura=" + leer + ",permisoModificar=" + modificar + ",permisoEliminar=" + eliminar + ",permisoImprimir=" + imprimir + " WHERE fkIdPerfil=" + perfil + " AND fkIdAplicacion=" + aplicacion + ";";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                MessageBox.Show("Asignación Exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Asignación:" + ex);
            }

        }

        public OdbcDataAdapter llenarpermisosUA(string tabla1)// metodo  que obtinene el contenido de una tabla
        {

            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla1 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter llenarpermisosPA(string tabla2)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla2 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public string consultaperfiln(string id)
        {

            string nombre = "";
            string Query = "select * from `componenteseguridad`.`Perfil` where pkid='" + id + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                nombre = busqueda["nombre"].ToString();

            }


            return nombre;
        }

        public string consultausuarion(string id)
        {

            string nombre = "";
            string Query = "select * from `componenteseguridad`.`Usuario` where pkid='" + id + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                nombre = busqueda["nombre"].ToString();

            }


            return nombre;
        }

        public string consultaaplicacionn(string id)
        {

            string nombre = "";
            string Query = "select * from `componenteseguridad`.`Aplicacion` where pkid='" + id + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                nombre = busqueda["nombre"].ToString();

            }


            return nombre;
        }
    }
}
