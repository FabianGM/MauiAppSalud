using MauiAppSalud.Models.Constantes;

namespace MauiAppSalud.Views;

public partial class PagosPage : ContentPage
{
    public PagosPage()
    {
        InitializeComponent();
        int idTipoServicio = Preferences.Get("idtiposervicio", Constantes.VALOR_CERO);
        string vposUrl = string.Empty;
        if (idTipoServicio == 2)
        {
            vposUrl = "https://checkout.wompi.co/l/ViBQRx";
        }

        if (idTipoServicio == 1)
        {
            vposUrl = "https://checkout.wompi.co/l/vss3Ru";
        }


        if (idTipoServicio == 6)
        {
            vposUrl = "https://checkout.wompi.co/l/9kppau";
        }

        if (idTipoServicio == 7)
        {
            vposUrl = "https://checkout.wompi.co/l/GaHspJ";
        }

        if (idTipoServicio == 8)
        {
            vposUrl = "https://checkout.wompi.co/l/28KaHu";
        }

        // URL directa del VPOS de Wompi
        ////string vposUrl = "https://checkout.wompi.co/l/VPOS_nkr1Nb";

        // Cargar la URL en el WebView
        WompiWebView.Source = vposUrl;
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
}
