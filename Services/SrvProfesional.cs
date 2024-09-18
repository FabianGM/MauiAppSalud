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
                    IdProfesional = lectura.GetInt32("id_profesionales"),
                    NombreCompleto = lectura.GetString("nombre_completo"),
                    Especialidad = lectura.GetString("especialidad"),
                    FotoPerfil = lectura.GetString("foto_perfil"),
                    Departamento = lectura.GetString("departamento"),
                    Ciudad = lectura.GetString("ciudad")
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

            // Filtrar por especialidad, departamento y ciudad como hasta ahora
            profesionalFiltro = profesionalFiltro.Where(oProfesional =>
                (string.IsNullOrWhiteSpace(especialidad) || oProfesional.Especialidad == especialidad) &&
                (string.IsNullOrWhiteSpace(departamento) || oProfesional.Departamento == departamento) &&
                (string.IsNullOrWhiteSpace(ciudad) || oProfesional.Ciudad == ciudad));

            // Filtro para aplicar búsqueda individualmente a cada campo si textoBusqueda no está vacío
            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                profesionalFiltro = profesionalFiltro.Where(oProfesional =>
                    (oProfesional.NombreCompleto ?? Constantes.VALOR_VACIO).Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    (oProfesional.Especialidad ?? Constantes.VALOR_VACIO).Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    (oProfesional.Departamento ?? Constantes.VALOR_VACIO).Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    (oProfesional.Ciudad ?? Constantes.VALOR_VACIO).Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase)
                );
            }

            return new ObservableCollection<ProfesionalMod>(profesionalFiltro.ToList());
        }


        /// <summary>
        /// Carga las ciudades desde la base de datos utilizando un procedimiento almacenado.
        /// </summary>
        /// <returns>Una coleccion observable de nombres de ciudades.</returns>
        public ObservableCollection<string> ObtenerCiudades()
        {
            ObservableCollection<string> ciudades = new ObservableCollection<string>();

            MySqlDataReader lectura = ejecutorSQL.EjecutarProcedimientoAlmacenado("ObtenerCiudades");

            while (lectura.Read())
            {
                ciudades.Add(lectura.GetString("nombre_ciudad"));
            }

            ejecutorSQL.CerrarConexion(lectura);
            return ciudades;
        }

        /// <summary>
        /// Carga los departamentos desde la base de datos utilizando un procedimiento almacenado.
        /// </summary>
        /// <returns>Una coleccion observable de nombres de departamentos.</returns>
        public ObservableCollection<string> ObtenerDepartamentos()
        {
            ObservableCollection<string> departamentos = new ObservableCollection<string>();

            MySqlDataReader lectura = ejecutorSQL.EjecutarProcedimientoAlmacenado("ObtenerDepartamentos");

            while (lectura.Read())
            {
                departamentos.Add(lectura.GetString("nombre_departamento"));
            }

            ejecutorSQL.CerrarConexion(lectura);
            return departamentos;
        }

        /// <summary>
        /// Carga las especialidades desde la base de datos utilizando un procedimiento almacenado.
        /// </summary>
        /// <returns>Una coleccion observable de nombres de especialidades.</returns>
        public ObservableCollection<string> ObtenerEspecialidades()
        {
            ObservableCollection<string> especialidades = new ObservableCollection<string>();

            MySqlDataReader lectura = ejecutorSQL.EjecutarProcedimientoAlmacenado("ObtenerEspecialidades");

            while (lectura.Read())
            {
                especialidades.Add(lectura.GetString("nombre_especialidad"));
            }

            ejecutorSQL.CerrarConexion(lectura);
            return especialidades;
        }
    }
}
