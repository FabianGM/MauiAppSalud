using MauiAppSalud.ViewModels;
using System.ComponentModel;

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

        // Evento que la interfaz de usuario escucha para saber si ha habido un cambio en una propiedad
        public event PropertyChangedEventHandler PropertyChanged;

        // Este método notifica a la UI que una propiedad ha cambiado
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
