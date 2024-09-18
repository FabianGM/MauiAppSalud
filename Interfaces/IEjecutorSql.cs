using MySqlConnector;
using System.Data;

namespace MauiAppSalud.Interfaces
{
    /// <summary>
    /// Interfaz para definir los métodos de ejecución de comandos SQL con MySQL.
    /// </summary>
    public interface IEjecutorSql
    {
        /// <summary>
        /// Ejecuta un procedimiento almacenado y devuelve un lector de datos.
        /// </summary>
        /// <param name="procedimientoAlmacenado">Nombre del procedimiento almacenado.</param>
        /// <returns>Un MySqlDataReader con los resultados de la consulta.</returns>
        MySqlDataReader EjecutarProcedimientoAlmacenado(string procedimientoAlmacenado);

        /// <summary>
        /// Ejecuta un procedimiento almacenado con parámetros y devuelve un lector de datos.
        /// </summary>
        /// <param name="procedimientoAlmacenado">Nombre del procedimiento almacenado.</param>
        /// <param name="parametros">Lista de parámetros a pasar al procedimiento almacenado.</param>
        /// <returns>Un MySqlDataReader con los resultados de la consulta.</returns>
        MySqlDataReader EjecutarProcedimientoAlmacenado(string procedimientoAlmacenado, List<MySqlParameter> parametros);

        /// <summary>
        /// Cierra el lector de datos y la conexión a la base de datos.
        /// </summary>
        /// <param name="lectura">El lector de datos MySqlDataReader a cerrar.</param>
        void CerrarConexion(MySqlDataReader lectura);
    }
}
