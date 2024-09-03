using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Controllers
{
    /// <summary>
    /// Controlador para manejar la logica de usuarios.
    /// </summary>
    public class UsuarioController
    {
        private readonly IUsuario sUsuario;

        /// <summary>
        /// Constructor que inyecta el servicio de usuarios.
        /// </summary>
        /// <param name="service">Instancia del servicio de usuario.</param>
        public UsuarioController(IUsuario usuario)
        {
            sUsuario = usuario;
        }

        /// <summary>
        /// Obtiene la lista de usuarios.
        /// </summary>
        /// <returns>Lista observable de usuarios.</returns>
        public ObservableCollection<UsuarioMod> ObtenerUsuarios()
        {
            return sUsuario.ObtenerUsuarios();
        }

        /// <summary>
        /// Agrega un nuevo usuario a la lista.
        /// </summary>
        /// <param name="usuario">Datos del usuario a agregar.</param>
        public void AgregarUsuario(UsuarioMod usuario)
        {
            sUsuario.AgregarUsuario(usuario);
        }

        /// <summary>
        /// Verifica las credenciales de inicio de sesion.
        /// </summary>
        /// <param name="correoElectronico">Correo electronico del usuario.</param>
        /// <param name="clave">clave del usuario.</param>
        /// <returns>Verdadero si las credenciales son correctas; de lo contrario, falso.</returns>
        public bool VerificarCredenciales(string correoElectronico, string clave)
        {
            return sUsuario.VerificarCredenciales(correoElectronico, clave);
        }
    }
}
