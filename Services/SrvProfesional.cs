using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;
using MauiAppSalud.Models.Constantes;
using MySqlConnector;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Services
{
    /// <summary>
    /// Servicio encargado de la gestion de los profesionales.
    /// </summary>
    public class SrvProfesional : IProfesional
    {
        private readonly IEjecutorSql ejecutorSQL;

        /// <summary>
        /// Constructor que inyecta el servicio de ejecucion SQL.
        /// </summary>
        public SrvProfesional()
        {
            ejecutorSQL = new SrvEjecutorSql(new SrvConexionBaseDatos());
        }

        /// <summary>
        /// Carga los profesionales desde la base de datos utilizando un procedimiento almacenado.
        /// </summary>
        /// <returns>Una coleccion observable de objetos ProfesionalMod.</returns>
        public ObservableCollection<ProfesionalMod> ObtenerProfesionales()
        {
            ObservableCollection<ProfesionalMod> profesionales = new ObservableCollection<ProfesionalMod>();

            MySqlDataReader lectura = ejecutorSQL.EjecutarProcedimientoAlmacenado("ObtenerProfesionales");

            while (lectura.Read())
            {
                profesionales.Add(new ProfesionalMod
                {
                    NombreCompleto = lectura.GetString("NombreCompleto"),
                    Especialidad = lectura.GetString("Especialidad"),
                    FotoPerfil = lectura.GetString("FotoPerfil"),
                    Departamento = lectura.GetString("Departamento"),
                    Ciudad = lectura.GetString("Ciudad")
                });
            }

            ejecutorSQL.CerrarConexion(lectura);
            return profesionales;
        }

        /// <summary>
        /// Filtra los profesionales basados en la especialidad, departamento, ciudad y texto de busqueda.
        /// </summary>
        /// <param name="especialidad">Especialidad del profesional.</param>
        /// <param name="departamento">Departamento donde ejerce el profesional.</param>
        /// <param name="ciudad">Ciudad donde ejerce el profesional.</param>
        /// <param name="textoBusqueda">Texto de busqueda que coincide con el nombre del profesional.</param>
        /// <returns>Una coleccion observable de objetos ProfesionalMod filtrados.</returns>
        public ObservableCollection<ProfesionalMod> FiltrarProfesionales(string especialidad, string departamento, string ciudad, string textoBusqueda)
        {
            IQueryable<ProfesionalMod> profesionalFiltro = ObtenerProfesionales().AsQueryable();

            profesionalFiltro = profesionalFiltro.Where(oProfesional =>
                (string.IsNullOrWhiteSpace(especialidad) || oProfesional.Especialidad == especialidad) &&
                (string.IsNullOrWhiteSpace(departamento) || oProfesional.Departamento == departamento) &&
                (string.IsNullOrWhiteSpace(ciudad) || oProfesional.Ciudad == ciudad) &&
                (string.IsNullOrWhiteSpace(textoBusqueda) || (oProfesional.NombreCompleto ?? Constantes.VALOR_VACIO).Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase)));

            return new ObservableCollection<ProfesionalMod>(profesionalFiltro.ToList());
        }
    }
}
