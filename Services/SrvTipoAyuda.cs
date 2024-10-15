using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;
using MySqlConnector;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Services
{
    /// <summary>
    /// Servicio encargado de obtener los tipos de ayuda o servicios asociados a un profesional.
    /// </summary>
    public class SrvTipoAyuda : ITipoAyuda
    {
        private readonly IEjecutorSql ejecutorSQL;

        /// <summary>
        /// Constructor que inyecta el servicio de ejecución SQL.
        /// </summary>
        public SrvTipoAyuda()
        {
            ejecutorSQL = new SrvEjecutorSql(new SrvConexionBaseDatos());
        }

        /// <summary>
        /// Obtiene los tipos de ayuda o servicios para un profesional específico.
        /// </summary>
        /// <param name="idProfesional">ID del profesional.</param>
        /// <returns>Una colección observable de objetos TipoAyudaMod.</returns>
        public ObservableCollection<TipoAyudaMod> ObtenerServiciosPorProfesional(int idProfesional)
        {
            ObservableCollection<TipoAyudaMod> serviciosDisponibles = new ObservableCollection<TipoAyudaMod>();

            try
            {
                // Configuración del parámetro
                var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@idProfesional", MySqlDbType.Int32) { Value = idProfesional }
            };

                // Ejecutar el procedimiento almacenado
                MySqlDataReader lectura = ejecutorSQL.EjecutarProcedimientoAlmacenado("ObtenerServiciosPorProfesional", parametros);

                // Leer los resultados
                while (lectura.Read())
                {
                    serviciosDisponibles.Add(new TipoAyudaMod
                    {
                        IdTipoAyuda = lectura.GetInt32("IdTipoAyuda"),
                        NombreServicio = lectura.GetString("NombreServicio"),
                        Duracion = lectura.GetString("Duracion"),
                        Precio = lectura.GetDecimal("Precio")
                    });
                }

                // Cerrar el lector de datos
                ejecutorSQL.CerrarConexion(lectura);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (opcional)
                Console.WriteLine("Error al obtener los servicios: " + ex.Message);
            }

            // Retornar la colección con los servicios disponibles
            return serviciosDisponibles;
        }

    }
}
