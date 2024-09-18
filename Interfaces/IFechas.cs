using MauiAppSalud.Models;

namespace MauiAppSalud.Interfaces
{
    /// <summary>
    /// Define las operaciones los horairos de los profesionales
    /// </summary>
    public interface IFechas
    {
        HorarioProfesionalMod ObtenerHorarioProfesional(int idProfesional);
    }
}
