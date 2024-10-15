using MauiAppSalud.Controllers;
using MauiAppSalud.Models;
using MauiAppSalud.Services;
using MauiAppSalud.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel;

namespace MauiAppSalud.Views;

[QueryProperty(nameof(IdProfesional), "idProfesional")]
public partial class CitasPacientesPage : ContentPage
{
    public string? IdProfesional { get; set; }
    private FechasController? cFechas = new FechasController(new SrvFechas());
    public HorarioProfesionalMod HorariosDoctores { get; set; }

    public CitasPacientesPage()
    {
        InitializeComponent();
        BindingContext = new CitasPacientesPageVmo();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Obtener los datos del profesional desde las preferencias
        string datosProfesional = Preferences.Get("datosprofesional", string.Empty);
        ProfesionalMod? oProfesional = JsonConvert.DeserializeObject<ProfesionalMod>(datosProfesional);

        // Obtener el horario del doctor
        HorariosDoctores = cFechas?.ObtenerHorarioProfesional(oProfesional?.IdProfesional ?? 0);

        if (HorariosDoctores != null)
        {
            // Asignar valores al DatePicker
            FechaCitaPicker.Date = HorariosDoctores.FechaInicio ?? DateTime.Now;
            FechaCitaPicker.MinimumDate = HorariosDoctores.FechaInicio ?? DateTime.Now;
            FechaCitaPicker.MaximumDate = HorariosDoctores.FechaFin ?? DateTime.Now.AddDays(7);

            // Generar intervalos de horas
            List<string> horasDisponibles = GenerarIntervaloHoras(
                HorariosDoctores.HoraInicio ?? new TimeSpan(9, 0, 0),
                HorariosDoctores.HoraFin ?? new TimeSpan(17, 0, 0),
                HorariosDoctores.IntervaloHorario);

            // Asignar los intervalos de hora al Picker
            HoraCitaPicker.ItemsSource = horasDisponibles;

            // Asignar una hora por defecto (primer valor de la lista)
            HoraCitaPicker.SelectedIndex = 0;
        }
        else
        {
            // Si no hay horarios disponibles, mostrar un rango por defecto
            FechaCitaPicker.Date = DateTime.Now;
            FechaCitaPicker.MinimumDate = DateTime.Now;
            FechaCitaPicker.MaximumDate = DateTime.Now.AddMonths(1); // Permitir citas en el próximo mes

            // Generar horarios por defecto
            List<string> horasDisponibles = GenerarIntervaloHoras(
                new TimeSpan(9, 0, 0),
                new TimeSpan(17, 0, 0),
                30);  // Intervalo de 30 minutos por defecto

            HoraCitaPicker.ItemsSource = horasDisponibles;

            // Asignar una hora por defecto
            HoraCitaPicker.SelectedIndex = 0;
        }
    }

    // Método para generar intervalos de horas en base al rango
    private List<string> GenerarIntervaloHoras(TimeSpan horaInicio, TimeSpan horaFin, int intervaloHorario)
    {
        List<string> horas = new List<string>();
        TimeSpan intervalo = new TimeSpan(0, intervaloHorario, 0); // Intervalo de minutos

        for (TimeSpan hora = horaInicio; hora <= horaFin; hora = hora.Add(intervalo))
        {
            horas.Add(hora.ToString(@"hh\:mm"));  // Formato HH:mm
        }

        return horas;
    }

    private async void OnConfirmarCitaClicked(object sender, EventArgs e)
    {
        // Obtener la fecha seleccionada en el DatePicker
        DateTime fechaSeleccionada = FechaCitaPicker.Date;

        // Obtener la hora seleccionada en el Picker de horas
        string horaSeleccionada = HoraCitaPicker.SelectedItem as string;

        // Validar si se seleccionó una hora
        if (horaSeleccionada == null)
        {
            await DisplayAlert("Cancelado", "Por favor selecciona una hora", "OK");
            return;
        }

        // Combinar fecha y hora para obtener la fecha completa de la cita
        DateTime fechaHoraCita = DateTime.Parse($"{fechaSeleccionada:yyyy-MM-dd} {horaSeleccionada}");
        Preferences.Set("fechaHoraCita", fechaHoraCita);

        // Navegar a la página de pagos
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
