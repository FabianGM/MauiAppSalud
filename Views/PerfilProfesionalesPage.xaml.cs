using MauiAppSalud.ViewModels;
using System.ComponentModel;

namespace MauiAppSalud.Views;

public partial class PerfilProfesionalesPage : ContentPage
{
    public PerfilProfesionalesPage()
    {
        InitializeComponent();
        BindingContext = new ProfesionalVmo();
    }

    /// <summary>
    /// Metodo manejador del evento TextChanged y SelectedIndexChanged
    /// </summary>
    /// <param name="sender">parametros</param>
    /// <param name="e">evento</param>
    private void OnFilterChanged(object sender, EventArgs e)
    {
        var viewModel = BindingContext as ProfesionalVmo;
        if (viewModel != null)
        {
            viewModel.ComandoBuscar?.Execute(null);
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
