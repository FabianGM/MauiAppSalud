using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;
using MySqlConnector;
using System.Data;

namespace MauiAppSalud.Services
{
    /// <summary>
    /// Servicio encargado de obtener los tipos de ayuda o servicios asociados a un profesional.
    /// </summary>
    public class SrvFechas : IFechas
    {
        private readonly IEjecutorSql ejecutorSQL;

        /// <summary>
        /// Constructor que inyecta el servicio de ejecución SQL.
        /// </summary>
        public SrvFechas()
        {
            ejecutorSQL = new SrvEjecutorSql(new SrvConexionBaseDatos());
        }

        public HorarioProfesionalMod ObtenerHorarioProfesional(int idProfesional)
        {
            HorarioProfesionalMod? oHorarioProfesional = new();

            // Configuración del parámetro
            var parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@p_id_profesionales", MySqlDbType.Int32) { Value = idProfesional }
            };

            // Ejecutar el procedimiento almacenado
            MySqlDataReader lectura = ejecutorSQL.EjecutarProcedimientoAlmacenado("ObtenerDisponibilidadDoctor", parametros);

            // Leer los resultados
            while (lectura.Read())
            {
                oHorarioProfesional = new HorarioProfesionalMod()
                {
                    FechaInicio = lectura.GetDateTime("fecha_inicio"),
                    FechaFin = lectura.GetDateTime("fecha_fin"),
                    HoraInicio = lectura.GetTimeSpan("hora_inicio"),
                    HoraFin = lectura.GetTimeSpan("hora_fin"),
                    IntervaloHorario = lectura.GetInt32("intervalo_horario")
                };
            }

            // Cerrar conexión
            ejecutorSQL.CerrarConexion(lectura);

            return oHorarioProfesional;
        }
    }
}
