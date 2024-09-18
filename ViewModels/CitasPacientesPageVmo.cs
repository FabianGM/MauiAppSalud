using MauiAppSalud.Controllers;
using MauiAppSalud.Models;
using MauiAppSalud.Services;

namespace MauiAppSalud.ViewModels
{
    /// <summary>
    /// ViewModel para gestionar los usuarios en la aplicacion.
    /// </summary>
    [QueryProperty(nameof(IdProfesional), "idProfesional")]
    public class CitasPacientesPageVmo
    {
        public string? IdProfesional { get; set; }

        private readonly FechasController? cFechas;
        public HorarioProfesionalMod HorariosDoctores { get; set; }

        public CitasPacientesPageVmo()
        {
            cFechas = new FechasController(new SrvFechas());
            HorariosDoctores = cFechas.ObtenerHorarioProfesional(int.Parse(IdProfesional));
        }
    }
}
