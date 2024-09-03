using MauiAppSalud.Models;
using MauiAppSalud.Interfaces;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Services
{
    /// <summary>
    /// Servicio encargado de la gestion de usuarios en la aplicacion.
    /// </summary>
    public class SrvUsuario : IUsuario
    {
        // Lista interna para almacenar los usuarios.
        private readonly ObservableCollection<UsuarioMod> usuarios = new ObservableCollection<UsuarioMod>();

        /// <summary>
        /// Verifica las credenciales de inicio de sesion.
        /// </summary>
        /// <param name="correoElectronico">Correo electronico del usuario.</param>
        /// <param name="clave">Contrasena del usuario.</param>
        /// <returns>Verdadero si las credenciales son correctas; de lo contrario, falso.</returns>
        public bool VerificarCredenciales(string correoElectronico, string clave)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.CorreoElectronico == correoElectronico && usuario.Clave == clave)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Obtiene la lista de usuarios registrados.
        /// </summary>
        /// <returns>Una coleccion observable de usuarios.</returns>
        public ObservableCollection<UsuarioMod> ObtenerUsuarios()
        {
            return usuarios;
        }

        /// <summary>
        /// Agrega un nuevo usuario a la lista de usuarios.
        /// </summary>
        /// <param name="nuevoUsuario">El usuario a agregar.</param>
        public void AgregarUsuario(UsuarioMod nuevoUsuario)
        {
            usuarios.Add(nuevoUsuario);
        }
    }
}
