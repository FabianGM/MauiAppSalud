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
            CadenaConexionMySql = "Server=localhost;Port=3307;Database=app_colombia_doctores;User=root;Password=;";
        }
    }
}
