using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaModelo;

namespace CapaControlador
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();

        //frmLogin
        public int InicarSesion(string Usuario, string Contraseña, int validar)
        {
            validar = sn.funIniciarSesion(Usuario, Contraseña, validar);

            return validar;
        }

        //frmMantenimientoAplicacion
        public void insertarAplicacion(string Id, string Nombre, int Estado, string Ruta)
        {
            sn.funInsertar(Id, Nombre, Estado, Ruta);
        }

        public void modificarAplicacion(string Id, string Nombre, int Estado, string Ruta)
        {
            sn.funModificar(Id, Nombre, Estado, Ruta);


        }

        public (string, int, string) buscarAplicacion(string id, string nombre, int estado, string ruta)
        {
            sn.funBuscar(id, nombre, estado, ruta);
            return (nombre, estado, ruta);
        }

        public void eliminarAplicacion(string id)
        {
            sn.funEliminar(id);
        }

        //frmPerfiles
        public DataTable PerfilllenarTbl(string tabla2)
        {
            OdbcDataAdapter dt = sn.PerfilllenarTbl(tabla2);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public DataTable PerfilllenarTblPersonal(string tabla2, string condicion)
        {
            OdbcDataAdapter dt = sn.PerfilllenarTblPersonal(tabla2, condicion);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public DataTable PerfilllenarNombre(string tabla, string condicion)
        {
            OdbcDataAdapter dt = sn.PerfilllenarNombre(tabla, condicion);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public void Perfilagregar(string tabla3, string valor1, string valor2)
        {
            sn.Perfilagregar(tabla3, valor1, valor2);
        }

        public void Perfileliminar(string tabla3, string valor1, string valor2)
        {
            sn.Perfileliminar(tabla3, valor1, valor2);
        }

        public void perfilPerfileliminartodo(string tabla3, string valor1)
        {
            sn.Perfileliminartodo(tabla3, valor1);
        }

        public void perfilPerfilagregartodo(string tabla3, string valor1, string valor2, string tabla2)
        {
            sn.Perfilagregartodo(tabla3, valor1, valor2, tabla2);
        }

        //frmApliaciones
        public DataTable aplicacionllenarTbl(string tabla2)
        {
            OdbcDataAdapter dt = sn.aplicacionllenarTbl(tabla2);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public DataTable aplicacionllenarTblPerfil(string tabla4)
        {
            OdbcDataAdapter dt = sn.aplicacionllenarTbl(tabla4);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public DataTable aplicacionllenarTblPersonal(string tabla2, string condicion)
        {
            OdbcDataAdapter dt = sn.aplicacionllenarTblPersonal(tabla2, condicion);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public DataTable aplicacionllenarNombre(string tabla, string condicion)
        {
            OdbcDataAdapter dt = sn.aplicacionllenarNombre(tabla, condicion);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public void aplicacionagregar(string tabla3, string valor1, string valor2)
        {
            sn.aplicacionagregar(tabla3, valor1, valor2);
        }

        public void aplicacioneliminar(string tabla3, string valor1, string valor2)
        {
            sn.aplicacioneliminar(tabla3, valor1, valor2);
        }

        public void aplicacioneliminartodo(string tabla3, string valor1)
        {
            sn.aplicacioneliminartodo(tabla3, valor1);
        }

        public void aplicacionagregartodo(string tabla3, string valor1, string valor2, string tabla2)
        {
            sn.aplicacionagregartodo(tabla3, valor1, valor2, tabla2);
        }




        //frmRecuperarContraseña
        //frmRContraseña
        public void recuperarContraseña(string Usuario, string Contraseña)
        {
            try
            {                             
                    sn.funRecuperar(Usuario, Contraseña);                
            }
            catch
            {
            }
        }

        public OdbcDataReader llenarcbo()
        {
            string sql = "SELECT nombre FROM componenteseguridad.usuario;";
            return sn.llenarcbxUsuario(sql);
        }


        //Mantenimiento Perfil


        public void insertarPerfil(string Id, string Nombre, int Estado)
        {
            sn.funInsertar(Id, Nombre, Estado);
        }

        public void modificarPerfil(string Id, string Nombre, int Estado)
        {
            sn.funModificar(Id, Nombre, Estado);


        }

        public (string, int) buscarPerfil(string id, string nombre, int estado, string ruta)
        {
            sn.funBuscar(id, nombre, estado);
            return (nombre, estado);
        }

        public void eliminarPerfil(string id)
        {
            sn.funEliminarPerfil(id);
        }

        //Aplicacion a perfiles
        public DataTable llenarTblappaperf(string tabla2)
        {
            OdbcDataAdapter dt = sn.llenarTblappaperf(tabla2);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public DataTable llenarTblPersonalappaperf(string tabla2, string condicion)
        {
            OdbcDataAdapter dt = sn.llenarTblPersonalappaperf(tabla2, condicion);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public DataTable llenarNombreappaperf(string tabla, string condicion)
        {
            OdbcDataAdapter dt = sn.llenarNombreappaperf(tabla, condicion);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public void agregarappaperf(string tabla3, string valor1, string valor2)
        {
            sn.agregarappaperf(tabla3, valor1, valor2);
        }

        public void eliminarappaperf(string tabla3, string valor1, string valor2)
        {
            sn.eliminarappaperf(tabla3, valor1, valor2);
        }

        public void perfileliminartodoappaperf(string tabla3, string valor1)
        {
            sn.perfileliminartodoappaperf(tabla3, valor1);
        }

        public void perfilagregartodoappaperf(string tabla3, string valor1, string valor2, string tabla2)
        {
            sn.perfilagregartodoappaperf(tabla3, valor1, valor2, tabla2);
        }

        //Cambiar contraseña

        public OdbcDataReader funcModificar_Contraseña(string Usuario, string Contraseña)
        {
            string Consulta = "UPDATE usuario SET contraseña = '" + Contraseña + "' where nombre = '" + Usuario + "';";
            return sn.funcModificar(Consulta);
        }
    }
}
