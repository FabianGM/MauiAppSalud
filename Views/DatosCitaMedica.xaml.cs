using MauiAppSalud.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace MauiAppSalud.Views;

public partial class DatosCitaMedica : ContentPage
{
    /// <summary>
    /// Constructor de la clase
    /// </summary>
    public DatosCitaMedica()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Accion cuando la pagina aparece en la pantalla
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Recupera los datos del profesional almacenados en las preferencias
        string datosProfesional = Preferences.Get("datosprofesional", string.Empty);
        
        // Deserializa los datos del profesional
        ProfesionalMod? oProfesional = JsonConvert.DeserializeObject<ProfesionalMod>(datosProfesional);

        // Verifica que la deserialización haya sido exitosa
        if (oProfesional != null)
        {
            // Asigna los valores a los controles de la interfaz de usuario
            NombreCompletoLabel.Text = oProfesional.NombreCompleto;
            EspecialidadLabel.Text = oProfesional.Especialidad;
        }
    }
    private async void OnPagoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("pagos");
    }

    // Evento que la interfaz de usuario escucha para saber si ha habido un cambio en una propiedad
    public event PropertyChangedEventHandler PropertyChanged;

    // Este método notifica a la UI que una propiedad ha cambiado
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
