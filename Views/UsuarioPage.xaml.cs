using MauiAppSalud.ViewModels;

namespace MauiAppSalud.Views
{
    /// <summary>
    /// Pagina de usuario que muestra el formulario de registro y la lista de usuarios registrados.
    /// </summary>
    public partial class UsuarioPage : ContentPage
    {
        /// <summary>
        /// Constructor de la pagina de usuario.
        /// Inicializa los componentes y configura el BindingContext con el ViewModel.
        /// </summary>
        public UsuarioPage()
        {
            InitializeComponent();
            BindingContext = new UsuarioVmo();
        }
    }
}
