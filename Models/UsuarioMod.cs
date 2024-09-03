namespace MauiAppSalud.Models
{
    /// <summary>
    /// Modelo que representa un usuario en la aplicacion.
    /// </summary>
    public class UsuarioMod
    {
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// Apellido del usuario.
        /// </summary>
        public string? Apellido { get; set; }

        /// <summary>
        /// Tipo de documento del usuario.
        /// </summary>
        public string? TipoDocumento { get; set; }

        /// <summary>
        /// Numero de documento del usuario.
        /// </summary>
        public string? NumeroDocumento { get; set; }

        /// <summary>
        /// Correo electronico del usuario.
        /// </summary>
        public string? CorreoElectronico { get; set; }

        /// <summary>
        /// Especialidad del usuario.
        /// </summary>
        public string? Especialidad { get; set; }

        /// <summary>
        /// Departamento o estado del pais donde reside el usuario.
        /// </summary>
        public string? DepartamentoPais { get; set; }

        /// <summary>
        /// Ciudad donde reside el usuario.
        /// </summary>
        public string? Ciudad { get; set; }

        /// <summary>
        /// Direccion del consultorio del usuario.
        /// </summary>
        public string? DireccionConsultorio { get; set; }

        /// <summary>
        /// Numero de telefono del usuario.
        /// </summary>
        public string? NumeroTelefono { get; set; }

        /// <summary>
        /// Experiencia y servicios del usuario.
        /// </summary>
        public string? ExperienciaUsuario { get; set; }

        /// <summary>
        /// Clave del usuario.
        /// </summary>
        public string? Clave { get; set; }

        /// <summary>
        /// Confirmacion de la clave del usuario.
        /// </summary>
        public string? ConfirmarClave { get; set; }
    }
}
