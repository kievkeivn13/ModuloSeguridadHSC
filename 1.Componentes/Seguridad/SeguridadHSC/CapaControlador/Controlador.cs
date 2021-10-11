using CapaModeloSeguridadHSC;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace CapaControladorSeguridadHSC
{
    public class Controlador
    {
        private Sentencias sn = new Sentencias();
        private llamarPermisos ll = new llamarPermisos();
        //Permisos de Botones




        public string definirpermisosperfil(string id, string p, string permiso, string t2, string pk, string app)
        {
            ll.llenarpermisos(id, p, permiso, t2, pk, app);


            MessageBox.Show(" 2da " + p);

            return p;

        }


        public void obteneraplicacion(string nombreapp, string idapp)
        {
            ll.obteneraplicacion(nombreapp, idapp);
        }


        //frmLogin
        public int InicarSesion(string Usuario, string Contraseña, int validar)
        {
            validar = sn.funIniciarSesion(Usuario, Contraseña, validar);

            return validar;
        }

        public int funIniciarSesion(string Usuario, string Contrasena)
        {
            int estado = sn.funInicio(Usuario, Contrasena);
            return estado;
        }
        //Controlador de bloquear usuario.
        public void funcBloquearUsuario(string Usuario)
        {
            string Consulta = "UPDATE componenteseguridad.usuario set estado= 0 where nombre= '" + Usuario + "';";
            sn.funcModificar(Consulta);
        }


        //frmMantenimientoAplicacion
        public void insertarAplicacion(string Id, string modulo, string nombre , int Estado, string RutaChm, string rutahtml)
        {
            sn.funInsertar(Id, modulo, nombre,  Estado, RutaChm, rutahtml);
        }

        public void modificarAplicacion(string Id, string modulo, string nombre, int Estado, string RutaChm, string rutahtml)
        {
            sn.funModificar(Id, modulo, nombre, Estado, RutaChm, rutahtml);
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

        public DataTable llenarTblAplicacion(string tabla)
        {
            OdbcDataAdapter dt = sn.llenarTblAplicacion(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public OdbcDataReader llenarcbxModulo()
        {
            string sql = "SELECT nombre FROM componenteseguridad.modulo;";
            return sn.llenarcbxUsuario(sql);
        }

        public string consultaModulo(string nombre)
        {
            string id = sn.consultaModulo(nombre);
            return id;
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

        public DataTable aplicacionllenarTblPersonal(string tabla2)
        {
            OdbcDataAdapter dt = sn.aplicacionllenarTblPersonal(tabla2);
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

        public void aplicacioneliminartodo(string tabla3)
        {
            sn.aplicacioneliminartodo(tabla3);
        }

        public void aplicacionagregartodo(string tabla3, string valor1, string valor2, string tabla2)
        {
            sn.aplicacionagregartodo(tabla3, valor1, valor2, tabla2);
        }

        public DataTable aplicacionllenarTblPersonal(string tabla3, string condicion)
        {
            OdbcDataAdapter dt = sn.aplicacionllenarTblPersonal(tabla3, condicion);
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



        public void aplicacioneliminartodo(string tabla3, string valor1)
        {
            sn.aplicacioneliminartodo(tabla3, valor1);
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

        public DataTable llenarTbl(string tabla)
        {
            OdbcDataAdapter dt = sn.llenarTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
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

        public void registrarUsuario(string pkId, string fkIdEmpleado, string nombre, string contraseña, string estado)
        {
            sn.registrarUsuario(pkId, fkIdEmpleado, nombre, contraseña, estado);
        }

        //frmPermisos
        public OdbcDataReader llenarcbxPerfil()
        {
            string sql = "SELECT nombre FROM componenteseguridad.perfil;";
            return sn.llenarcbxUsuario(sql);
        }
        public OdbcDataReader llenarcbxUsuarios()
        {
            string sql = "SELECT nombre FROM componenteseguridad.usuario;";
            return sn.llenarcbxUsuario(sql);
        }

        public OdbcDataReader llenarcbxAplicacion()
        {
            string sql = "SELECT nombre FROM componenteseguridad.aplicacion;";
            return sn.llenarcbxUsuario(sql);
        }

        public string consultausuario(string nombre)
        {
            string id = sn.consultausuario(nombre);
            return id;
        }

        public string consultaperfil(string nombre)
        {
            string id = sn.consultaperfil(nombre);
            return id;
        }

        public string consultaaplicacion(string nombre)
        {
            string id = sn.consultaaplicacion(nombre);
            return id;
        }

        public void InsertarPPerApl(string perfil, string aplicacion, int escribir, int leer, int modificar, int eliminar, int imprimir)
        {
            sn.InsertarPPerApl(perfil, aplicacion, escribir, leer, modificar, eliminar, imprimir);
        }

        public void InsertarUsuApl(string usuario, string aplicacion, int escribir, int leer, int modificar, int eliminar, int imprimir)
        {
            sn.InsertarPUsuApl(usuario, aplicacion, escribir, leer, modificar, eliminar, imprimir);
        }

        public DataTable llenarpermisosUA(string tabla1)
        {
            OdbcDataAdapter dt = sn.llenarpermisosUA(tabla1);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public DataTable llenarpermisosPA(string tabla2)
        {
            OdbcDataAdapter dt = sn.llenarpermisosPA(tabla2);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public string consultausuarion(string id)
        {
            string nombre = sn.consultausuarion(id);
            return nombre;
        }

        public string consultaperfiln(string id)
        {
            string nombre = sn.consultaperfiln(id);
            return nombre;
        }

        public string consultaaplicacionn(string id)
        {
            string nombre = sn.consultaaplicacionn(id);
            return nombre;
        }

    }
}