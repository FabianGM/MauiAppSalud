using MauiAppSalud.Controllers;
using MauiAppSalud.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiAppSalud.Services;
using Newtonsoft.Json;

namespace MauiAppSalud.ViewModels
{
    /// <summary>
    /// ViewModel para gestionar la logica de busqueda y filtrado de profesionales.
    /// </summary>
    public class ProfesionalVmo : BaseVmo
    {
        // Controlador para manejar la logica relacionada con los profesionales
        private readonly ProfesionalController cProfesional;

        // Campo privado que almacena el departamento seleccionado por el usuario.
        private string? _departamentoSeleccionado;

        // Campo privado que almacena la ciudad seleccionada por el usuario.
        private string? _ciudadSeleccionada;

        // Campo privado que almacena la especialidad seleccionada por el usuario.
        private string? _especialidadSeleccionada;

        /// <summary>
        /// Coleccion de especialidades disponibles para el filtro.
        /// </summary>
        public ObservableCollection<string>? Especialidades { get; }

        /// <summary>
        /// Coleccion de departamentos disponibles para el filtro.
        /// </summary>
        public ObservableCollection<string>? Departamentos { get; }

        /// <summary>
        /// Coleccion de ciudades disponibles para el filtro.
        /// </summary>
        public ObservableCollection<string>? Ciudades { get; }

        /// <summary>
        /// Coleccion de profesionales obtenidos segun los filtros aplicados.
        /// </summary>
        public ObservableCollection<ProfesionalMod> Profesionales { get; set; }

        /// <summary>
        /// Texto de busqueda ingresado por el usuario para buscar profesionales por nombre.
        /// </summary>
        public string? TextoBusqueda { get; set; }

        /// <summary>
        /// Comando que se ejecuta cuando el usuario presiona el boton de buscar.
        /// </summary>
        public ICommand? ComandoBuscar { get; }

        /// <summary>
        /// Comando que se ejecuta cuando el usuario presiona el boton para ver mas detalles del profesional.
        /// </summary>
        public ICommand? VerMasCommand { get; }

        /// <summary>
        /// Comando que se ejecuta para limpiar los filtros de busqueda.
        /// </summary>
        public ICommand ClearFieldCommand { get; }

        /// <summary>
        /// Propiedad que almacena la especialidad seleccionada por el usuario.
        /// </summary>
        public string? EspecialidadSeleccionada
        {
            get => _especialidadSeleccionada;
            set
            {
                _especialidadSeleccionada = value;
                OnPropertyChanged(nameof(EspecialidadSeleccionada));
            }
        }

        /// <summary>
        /// Propiedad que almacena el departamento seleccionado por el usuario.
        /// </summary>
        public string? DepartamentoSeleccionado
        {
            get => _departamentoSeleccionado;
            set
            {
                _departamentoSeleccionado = value;
                OnPropertyChanged(nameof(DepartamentoSeleccionado));
            }
        }

        /// <summary>
        /// Propiedad que almacena la ciudad seleccionada por el usuario.
        /// </summary>
        public string? CiudadSeleccionada
        {
            get => _ciudadSeleccionada;
            set
            {
                _ciudadSeleccionada = value;
                OnPropertyChanged(nameof(CiudadSeleccionada));
            }
        }

        /// <summary>
        /// Constructor que inicializa los comandos y carga las listas de especialidades, departamentos y ciudades.
        /// </summary>
        public ProfesionalVmo()
        {
            cProfesional = new ProfesionalController(new SrvProfesional());

            // Inicializacion de las colecciones de filtros
            Especialidades = cProfesional.ObtenerEspecialidades();
            Departamentos = cProfesional.ObtenerDepartamentos();
            Ciudades = cProfesional.ObtenerCiudades();
            Profesionales = cProfesional.ObtenerProfesionales();

            // Inicializacion de comandos
            ComandoBuscar = new Command(BuscarProfesionales);

            VerMasCommand = new Command<ProfesionalMod>(async (parametros) =>
            {
                await Shell.Current.GoToAsync($"detallesProfesional?idProfesional={parametros.IdProfesional}&nombre={parametros.NombreCompleto}&especialidad={parametros.Especialidad}&fotoPerfil={parametros.FotoPerfil}");
                Preferences.Set("datosprofesional", JsonConvert.SerializeObject(parametros));
            });

            ClearFieldCommand = new Command<string>((fieldName) =>
            {
                switch (fieldName)
                {
                    case "Especialidad":
                        EspecialidadSeleccionada = null;
                        break;
                    case "Departamento":
                        DepartamentoSeleccionado = null;
                        break;
                    case "Ciudad":
                        CiudadSeleccionada = null;
                        break;
                }
                ComandoBuscar.Execute(null);
            });
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
