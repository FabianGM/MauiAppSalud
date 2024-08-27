using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;

namespace MauiAppSalud.Controllers
{
    public class UsuarioController
    {
        private readonly IUsuario _usuarioService;

        public UsuarioController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void CrearUsuario(string nombre, string correoElectronico, string contraseña)
        {
            _usuarioService.CrearUsuario(nombre, correoElectronico, contraseña);
        }

        public IEnumerable<UsuarioMod> ObtenerUsuarios()
        {
            return _usuarioService.ObtenerUsuarios();
        }
    }
}
