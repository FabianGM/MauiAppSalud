namespace MauiAppSalud.Models
{
    /// <summary>
    /// Modelo que representa a un profesional de la salud.
    /// </summary>
    public class HorarioProfesionalMod
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public int IntervaloHorario { get; set; }   
    }
}
