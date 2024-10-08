using MySqlConnector;

namespace MauiAppSalud.Services
{
    /// <summary>
    /// Servicio encargado de manejar la conexion a la base de datos MySQL.
    /// </summary>
    public class SrvConexionBaseDatos
    {
        /// <summary>
        /// La cadena de conexion a la base de datos MySQL.
        /// </summary>
        public string CadenaConexionMySql { get; set; }

        /// <summary>
        /// Constructor que inicializa la cadena de conexion.
        /// </summary>
        public SrvConexionBaseDatos()
        {
            ////CadenaConexionMySql = "Server=192.168.100.23;Port=3307;Database=app_colombia_doctores;User=root;Password=;";
            CadenaConexionMySql = "Server=190.90.160.166;Port=3306;Database=madreseg_app_colombia_doctores;User=madreseg_colombia_doctores;Password=Fabi24@@@@@@@@@@@@@@@@;";
        }
    }
}
