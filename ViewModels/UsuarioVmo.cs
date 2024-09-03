using MauiAppSalud.Controllers;
using MauiAppSalud.Models;
using MauiAppSalud.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiAppSalud.ViewModels
{
    /// <summary>
    /// ViewModel para gestionar los usuarios en la aplicacion.
    /// </summary>
    public class UsuarioVmo
    {
        private readonly UsuarioController cUsuario;

        /// <summary>
        /// Modelo que contiene los datos del usuario actual.
        /// Se utiliza para el enlace de datos en la vista.
        /// </summary>
        public UsuarioMod NuevoUsuario { get; set; }

        /// <summary>
        /// Lista de usuarios obtenida del controlador.
        /// Esta lista se vincula directamente a la vista para mostrar los usuarios registrados.
        /// </summary>
        public ObservableCollection<UsuarioMod> Usuarios => cUsuario.ObtenerUsuarios();

        /// <summary>
        /// Comando para crear un nuevo usuario.
        /// Este comando se vincula a la accion del usuario en la interfaz (como un boton).
        /// </summary>
        public ICommand CrearUsuarioCommand { get; }

        /// <summary>
        /// Constructor del ViewModel.
        /// Inicializa el controlador de usuarios y los comandos.
        /// </summary>
        public UsuarioVmo()
        {
            cUsuario = new UsuarioController(new SrvUsuario());
            NuevoUsuario = new UsuarioMod();

            CrearUsuarioCommand = new Command(() =>
            {
                cUsuario.AgregarUsuario(NuevoUsuario);
                NuevoUsuario = new UsuarioMod();
            });
        }
    }
}
