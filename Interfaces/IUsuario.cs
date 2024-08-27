using MauiAppSalud.Models;

namespace MauiAppSalud.Interfaces
{
    public interface IUsuario
    {
        void CrearUsuario(string nombre, string correoElectronico, string clave);
        IEnumerable<UsuarioMod> ObtenerUsuarios();
    }
}
