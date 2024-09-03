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
        private readonly IProfesional profesionalService;

        /// <summary>
        /// Constructor que inyecta el servicio de profesionales.
        /// </summary>
        public ProfesionalController(IProfesional service)
        {
            profesionalService = service;
        }

        /// <summary>
        /// Obtiene la lista de todos los profesionales.
        /// </summary>
        public ObservableCollection<ProfesionalMod> ObtenerProfesionales()
        {
            return profesionalService.ObtenerProfesionales();
        }

        /// <summary>
        /// Filtra los profesionales basados en la especialidad, departamento y ciudad.
        /// </summary>
        public ObservableCollection<ProfesionalMod> FiltrarProfesionales(string especialidad, string departamento, string ciudad, string textoBusqueda)
        {
            return profesionalService.FiltrarProfesionales(especialidad, departamento, ciudad, textoBusqueda);
        }
    }
}
