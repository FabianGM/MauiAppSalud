using MauiAppSalud.Models;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Interfaces
{
    /// <summary>
    /// Define las operaciones del servicio de usuario.
    /// </summary>
    public interface IUsuario
    {
        /// <summary>
        /// Obtiene la lista de usuarios registrados.
        /// </summary>
        ObservableCollection<UsuarioMod> ObtenerUsuarios();

        /// <summary>
        /// Verifica las credenciales de inicio de sesion.
        /// </summary>
        /// <param name="correoElectronico">Correo electronico del usuario.</param>
        /// <param name="clave">Clave del usuario.</param>
        /// <returns>Verdadero si las credenciales son correctas; de lo contrario, falso.</returns>
        bool VerificarCredenciales(string correoElectronico, string clave);

        /// <summary>
        /// Agrega un nuevo usuario a la lista de usuarios.
        /// </summary>
        /// <param name="nuevoUsuario">El usuario a agregar.</param>
        void AgregarUsuario(UsuarioMod nuevoUsuario);
    }
}
