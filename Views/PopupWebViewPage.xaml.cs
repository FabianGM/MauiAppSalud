using System.ComponentModel;

namespace MauiAppSalud.Views;

public partial class PopupWebViewPage : ContentPage
{
    public PopupWebViewPage(string url)
    {
        InitializeComponent();

        // Cargar la URL recibida en el nuevo WebView
        PopupWebView.Source = url;
    }

    // Una vez que la ventana emergente haya completado su acción, puedes regresar a la página principal
    private async void OnNavigated(object sender, WebNavigatedEventArgs e)
    {
        // Cuando la navegación esté completa, puedes regresar automáticamente a la página principal
        if (e.NavigationEvent == WebNavigationEvent.Back || e.Url.Contains("complete"))
        {
            // Regresar a la página principal
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
