using MauiAppSalud.Models.Constantes;
using System.ComponentModel;

namespace MauiAppSalud.Views;

public partial class PagosPage : ContentPage
{
    private static readonly Dictionary<int, string> ServicioUrls = new Dictionary<int, string>
    {
        { 1, "https://checkout.wompi.co/l/vss3Ru" },
        { 2, "https://checkout.wompi.co/l/ViBQRx" },
        { 6, "https://checkout.wompi.co/l/9kppau" },
        { 7, "https://checkout.wompi.co/l/GaHspJ" },
        { 8, "https://checkout.wompi.co/l/28KaHu" },
        { 9, "https://checkout.wompi.co/l/ViBQRx" }
    };

    public PagosPage()
    {
        InitializeComponent();

        // Obtener el idTipoServicio desde las preferencias
        int idTipoServicio = Preferences.Get("idtiposervicio", Constantes.VALOR_CERO);

        // Buscar la URL en el diccionario
        if (ServicioUrls.TryGetValue(idTipoServicio, out string vposUrl))
        {
            // Cargar la URL en el WebView si se encuentra
            WompiWebView.Source = vposUrl;
        }
        else
        {
            // Si no se encuentra el idTipoServicio, manejar el caso (opcional)
            DisplayAlert("Error", "No se encontró una URL válida para el tipo de servicio.", "Aceptar");
        }
    }

    // Manejar enlaces externos o emergentes
    private async void OnNavigating(object sender, WebNavigatingEventArgs e)
    {
        // Si detectas que es un enlace que requiere una nueva ventana (emergente)
        if (e.Url.Contains("popup") || e.NavigationEvent == WebNavigationEvent.NewPage)
        {
            e.Cancel = true; // Cancelar la navegación en el WebView actual

            // Navegar a la nueva página para manejar la ventana emergente
            await Navigation.PushAsync(new PopupWebViewPage(e.Url));

            // Volver a la página principal una vez completado
            await Navigation.PopToRootAsync();
        }
    }

    // Evento que la interfaz de usuario escucha para saber si ha habido un cambio en una propiedad
    public event PropertyChangedEventHandler PropertyChanged;

    // Este método notifica a la UI que una propiedad ha cambiado
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
