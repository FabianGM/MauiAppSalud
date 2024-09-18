namespace MauiAppSalud.Models
{
    public class TipoAyudaMod
    {
        /// <summary>
        /// Id del tipo de ayuda
        /// </summary>
        public int IdTipoAyuda { get; set; }

        /// <summary>
        /// Nombre del servicio o tipo de ayuda.
        /// </summary>
        public string? NombreServicio { get; set; }

        /// <summary>
        /// Duracion del servicio.
        /// </summary>
        public string? Duracion { get; set; }

        /// <summary>
        /// Precio del servicio.
        /// </summary>
        public decimal? Precio { get; set; }
    }
}
