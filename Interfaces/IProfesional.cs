using MauiAppSalud.Models;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Interfaces
{
    /// <summary>
    /// Define las operaciones del servicio de profesionales.
    /// </summary>
    public interface IProfesional
    {
        /// <summary>
        /// Obtiene la lista de todos los profesionales.
        /// </summary>
        ObservableCollection<ProfesionalMod> ObtenerProfesionales();

        /// <summary>
        /// Filtra los profesionales basados en la especialidad, departamento y ciudad.
        /// </summary>
        ObservableCollection<ProfesionalMod> FiltrarProfesionales(string especialidad, string departamento, string ciudad, string textoBusqueda);
    }
}
