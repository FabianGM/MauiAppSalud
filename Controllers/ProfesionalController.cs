using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Controllers
{
    /// <summary>
    /// Controlador para manejar la logica de los profesionales.
    /// </summary>
    public class ProfesionalController
    {
        private readonly IProfesional sProfesional;

        /// <summary>
        /// Constructor que inyecta el servicio de profesionales.
        /// </summary>
        public ProfesionalController(IProfesional service)
        {
            sProfesional = service;
        }

        /// <summary>
        /// Obtiene la lista de todos los profesionales.
        /// </summary>
        public ObservableCollection<ProfesionalMod> ObtenerProfesionales()
        {
            return sProfesional.ObtenerProfesionales();
        }

        /// <summary>
        /// Filtra los profesionales basados en la especialidad, departamento y ciudad.
        /// </summary>
        public ObservableCollection<ProfesionalMod> FiltrarProfesionales(string especialidad, string departamento, string ciudad, string textoBusqueda)
        {
            return sProfesional.FiltrarProfesionales(especialidad, departamento, ciudad, textoBusqueda);
        }

        /// <summary>
        /// Obtiene todos los departamentos.
        /// </summary>
        /// <returns>Lista de nombres de departamentos.</returns>
        public ObservableCollection<string> ObtenerDepartamentos()
        {
            return sProfesional.ObtenerDepartamentos();
        }

        /// <summary>
        /// Obtiene todas las especialidades.
        /// </summary>
        /// <returns>Lista de nombres de especialidades.</returns>
        public ObservableCollection<string> ObtenerEspecialidades()
        {
            return sProfesional.ObtenerEspecialidades();
        }

        /// <summary>
        /// Obtiene todas las ciudades.
        /// </summary>
        /// <returns>Lista de nombres de ciudades.</returns>
        public ObservableCollection<string> ObtenerCiudades()
        {
            return sProfesional.ObtenerCiudades();
        }
    }
}
