namespace MauiAppSalud.Models
{
    /// <summary>
    /// Modelo que representa a un profesional de la salud.
    /// </summary>
    public class ProfesionalMod
    {
        /// <summary>
        /// Id del profesional
        /// </summary>
        public int IdProfesional { get; set; }

        /// <summary>
        /// Nombre completo del profesional.
        /// </summary>
        public string? NombreCompleto { get; set; }

        /// <summary>
        /// Especialidad del profesional.
        /// </summary>
        public string? Especialidad { get; set; }

        /// <summary>
        /// Ruta de la foto de perfil del profesional.
        /// </summary>
        public string? FotoPerfil { get; set; }

        /// <summary>
        /// Departamento o estado del pais donde trabaja el profesional.
        /// </summary>
        public string? Departamento { get; set; }

        /// <summary>
        /// Ciudad donde trabaja el profesional.
        /// </summary>
        public string? Ciudad { get; set; }
    }
}
