using MauiAppSalud.Models;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Interfaces
{
    /// <summary>
    /// Define las operaciones del tipo de ayuda del usuario.
    /// </summary>
    public interface ITipoAyuda
    {
        /// <summary>
        /// Carga los tipos de ayuda que puede tener los profesionales desde la base de datos utilizando un procedimiento almacenado.
        /// </summary>
        /// <returns>Una coleccion observable de objetos TipoAyudaMod.</returns>
        ObservableCollection<TipoAyudaMod> ObtenerServiciosPorProfesional(int idProfesional);
    }
}
