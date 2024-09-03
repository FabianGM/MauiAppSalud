using MauiAppSalud.ViewModels;

namespace MauiAppSalud.Views;

public partial class PerfilProfesionalesPage : ContentPage
{
	public PerfilProfesionalesPage()
	{
		InitializeComponent();
        BindingContext = new ProfesionalVmo();
    }
}