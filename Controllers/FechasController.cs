using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Controllers
{
    /// <summary>
    /// Controlador para manejar la logica para los horaios de los profesionales.
    /// </summary>
    public class FechasController
    {
        private readonly IFechas sFechas;

        public FechasController(IFechas fechas)
        {
            sFechas = fechas;
        }

        public HorarioProfesionalMod ObtenerHorarioProfesional(int idProfesional)
        {
            return sFechas.ObtenerHorarioProfesional(idProfesional);
        }
    }
}
