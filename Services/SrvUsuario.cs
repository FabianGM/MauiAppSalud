using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;

namespace MauiAppSalud.Services
{
    public class SrvUsuario : IUsuario
    {
        private readonly List<UsuarioMod> usuarios = new();

        public void CrearUsuario(string nombre, string correoElectronico, string clave)
        {
            var nuevoUsuario = new UsuarioMod
            {
                Nombre = nombre,
                CorreoElectronico = correoElectronico,
                Clave = clave
            };

            usuarios.Add(nuevoUsuario);
        }

        public IEnumerable<UsuarioMod> ObtenerUsuarios()
        {
            return usuarios;
        }
    }
}
