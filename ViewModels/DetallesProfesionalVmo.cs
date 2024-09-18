using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiAppSalud.Controllers;
using MauiAppSalud.Models;
using MauiAppSalud.Models.Constantes;
using MauiAppSalud.Services;
using Newtonsoft.Json;

namespace MauiAppSalud.ViewModels
{
    /// <summary>
    /// ViewModel para gestionar los detalles del profesional y sus servicios disponibles.
    /// </summary>
    public class DetallesProfesionalVmo : BaseVmo
    {
        /// <summary>
        /// Colección observable de servicios disponibles.
        /// </summary>
        public ObservableCollection<TipoAyudaMod> ServiciosDisponibles { get; set; }

        /// <summary>
        /// Comando para continuar con el servicio seleccionado.
        /// </summary>
        public ICommand ComandoContinuar { get; }

        /// <summary>
        /// Controlador para manejar los tipos de ayuda del sistema.
        /// </summary>
        public TipoAyudaController cTipoAyuda { get; set; }

        /// <summary>
        /// Constructor sin parametros que inicializa los datos y comandos.
        /// </summary>
        public DetallesProfesionalVmo()
        {
            cTipoAyuda = new TipoAyudaController(new SrvTipoAyuda());
            int idProfesional = Preferences.Get("idProfesional", Constantes.VALOR_CERO);
            ServiciosDisponibles = cTipoAyuda.ObtenerTipoAyuda(idProfesional);
            ComandoContinuar = new Command<TipoAyudaMod>(ContinuarConServicio);
        }

        /// <summary>
        /// Metodo que se ejecuta cuando el usuario selecciona un servicio y presiona el boton "Continuar".
        /// </summary>
        /// <param name="servicio">El servicio seleccionado.</param>
        private async void ContinuarConServicio(TipoAyudaMod servicio)
        {
            await Shell.Current.GoToAsync("citasPacientes");
        }
    }
}
