using MauiAppSalud.ViewModels;

namespace MauiAppSalud.Views
{
    [QueryProperty(nameof(IdProfesional), "idProfesional")]
    [QueryProperty(nameof(NombreCompleto), "nombre")]
    [QueryProperty(nameof(Especialidad), "especialidad")]
    [QueryProperty(nameof(FotoPerfil), "fotoPerfil")]
    public partial class DetallesProfesionalPage : ContentPage
    {
        /// <summary>
        /// Id del profesional
        /// </summary>
        public int IdProfesional { get; set; }

        /// <summary>
        /// Nombre completo del profesional
        /// </summary>
        public string? NombreCompleto { get; set; }

        /// <summary>
        /// Especialidad del profesional
        /// </summary>
        public string? Especialidad { get; set; }

        /// <summary>
        /// Foto de perfil del profesional
        /// </summary>
        public string? FotoPerfil { get; set; }

        public DetallesProfesionalPage()
        {
            InitializeComponent();
            BindingContext = new DetallesProfesionalVmo();
        }

        /// <summary>
        /// Accion cuando la pagina aparece en la pantalla
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Preferences.Set("idProfesional", IdProfesional);
            NombreCompletoLabel.Text = NombreCompleto;
            EspecialidadLabel.Text = Especialidad;
            FotoPerfilImage.Source = FotoPerfil;
        }
    }
}
