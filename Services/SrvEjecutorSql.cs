using MauiAppSalud.Interfaces;
using MySqlConnector;
using System.Data;

namespace MauiAppSalud.Services
{
    /// <summary>
    /// Servicio para manejar la ejecucion de comandos SQL con MySQL.
    /// </summary>
    public class SrvEjecutorSql : IEjecutorSql
    {
        private readonly SrvConexionBaseDatos cadenaConexion;

        /// <summary>
        /// Constructor que recibe la cadena de conexion inyectada.
        /// </summary>
        /// <param name="conexion">Cadena de conexion a la base de datos MySQL.</param>
        public SrvEjecutorSql(SrvConexionBaseDatos conexion)
        {
            cadenaConexion = conexion;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y devuelve un lector de datos.
        /// </summary>
        /// <param name="procedimientoAlmacenado">Nombre del procedimiento almacenado.</param>
        /// <returns>Un MySqlDataReader con los resultados de la consulta.</returns>
        public MySqlDataReader EjecutarProcedimientoAlmacenado(string procedimientoAlmacenado)
        {
            var conexion = new MySqlConnection(cadenaConexion.CadenaConexionMySql);
            conexion.Open();

            var command = new MySqlCommand(procedimientoAlmacenado, conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// Cierra el lector de datos y la conexion a la base de datos.
        /// </summary>
        /// <param name="lectura">El lector de datos MySqlDataReader a cerrar.</param>
        public void CerrarConexion(MySqlDataReader lectura)
        {
            if (lectura != null && !lectura.IsClosed)
            {
                lectura.Close();
                lectura.Dispose();
            }
        }
    }
}
