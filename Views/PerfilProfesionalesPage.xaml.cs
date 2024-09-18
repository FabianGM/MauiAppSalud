using MauiAppSalud.ViewModels;

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
}
