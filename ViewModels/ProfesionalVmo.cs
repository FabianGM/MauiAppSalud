using MauiAppSalud.Controllers;
using MauiAppSalud.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiAppSalud.Services;

namespace MauiAppSalud.ViewModels
{
    /// <summary>
    /// ViewModel para manejar la logica de busqueda de profesionales.
    /// </summary>
    public class ProfesionalVmo : BaseVmo
    {
        private readonly ProfesionalController cProfesional;

        /// <summary>
        /// Coleccion de especialidades disponibles para filtrar.
        /// </summary>
        public ObservableCollection<string>? Especialidades { get; }

        /// <summary>
        /// Especialidad seleccionada actualmente en el filtro.
        /// </summary>
        public string? EspecialidadSeleccionada { get; set; }

        /// <summary>
        /// Coleccion de departamentos disponibles para filtrar.
        /// </summary>
        public ObservableCollection<string>? Departamentos { get; }

        /// <summary>
        /// Departamento seleccionado actualmente en el filtro.
        /// </summary>
        public string? DepartamentoSeleccionado { get; set; }

        /// <summary>
        /// Coleccion de ciudades disponibles para filtrar.
        /// </summary>
        public ObservableCollection<string>? Ciudades { get; }

        /// <summary>
        /// Ciudad seleccionada actualmente en el filtro.
        /// </summary>
        public string? CiudadSeleccionada { get; set; }

        /// <summary>
        /// Lista de profesionales obtenida del controlador.
        /// Esta lista se vincula directamente a la vista para mostrar los profesionales registrados.
        /// </summary>
        public ObservableCollection<ProfesionalMod> Profesionales { get; set; }

        /// <summary>
        /// Texto de busqueda ingresado por el usuario.
        /// </summary>
        public string? TextoBusqueda { get; set; }

        /// <summary>
        /// Comando que se ejecuta cuando se presiona el boton de buscar.
        /// </summary>
        public ICommand? ComandoBuscar { get; }

        /// <summary>
        /// Constructor por defecto que inicializa los datos y comandos.
        /// </summary>
        public ProfesionalVmo()
        {
            cProfesional = new ProfesionalController(new SrvProfesional());

            Especialidades = new ObservableCollection<string> { "Oftalmología", "Medicina General", "Pediatría" };
            Departamentos = new ObservableCollection<string> { "Antioquia", "Cundinamarca", "Valle del Cauca" };
            Ciudades = new ObservableCollection<string> { "Medellín", "Bogotá", "Cali" };
            Profesionales = cProfesional.ObtenerProfesionales();
            ComandoBuscar = new Command(BuscarProfesionales);
        }

        /// <summary>
        /// Metodo que filtra los profesionales basados en los filtros seleccionados.
        /// </summary>
        private void BuscarProfesionales()
        {
            Profesionales = cProfesional.FiltrarProfesionales(
                EspecialidadSeleccionada ?? string.Empty,
                DepartamentoSeleccionado ?? string.Empty,
                CiudadSeleccionada ?? string.Empty,
                TextoBusqueda ?? string.Empty);

            OnPropertyChanged(nameof(Profesionales));
        }
    }
}
