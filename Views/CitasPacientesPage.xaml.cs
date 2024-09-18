using MauiAppSalud.Controllers;
using MauiAppSalud.Models;
using MauiAppSalud.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
            FechaCitaPicker.Date = HorariosDoctores.FechaInicio ?? DateTime.Now;  // Fecha por defecto si es nulo
            FechaCitaPicker.MinimumDate = HorariosDoctores.FechaInicio ?? DateTime.Now;
            FechaCitaPicker.MaximumDate = HorariosDoctores.FechaFin ?? DateTime.Now.AddDays(7);

            // Generar intervalos de horas
            List<string> horasDisponibles = GenerarIntervaloHoras(HorariosDoctores.HoraInicio ?? new TimeSpan(9, 0, 0),
                                                                  HorariosDoctores.HoraFin ?? new TimeSpan(17, 0, 0), HorariosDoctores.IntervaloHorario);

            // Asignar los intervalos de hora al Picker
            HoraCitaPicker.ItemsSource = horasDisponibles;
        }
        else
        {
            // Si no hay horarios disponibles, mostrar un rango por defecto
            FechaCitaPicker.Date = DateTime.Now;
            FechaCitaPicker.MinimumDate = DateTime.Now;
            FechaCitaPicker.MaximumDate = DateTime.Now.AddMonths(1); // Permitir citas en el pr�ximo mes

            // Generar horarios por defecto
            List<string> horasDisponibles = GenerarIntervaloHoras(new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0), HorariosDoctores.IntervaloHorario);
            HoraCitaPicker.ItemsSource = horasDisponibles;
        }
    }

    // M�todo para generar intervalos de horas en base al rango
    private List<string> GenerarIntervaloHoras(TimeSpan horaInicio, TimeSpan horaFin, int intervaloHorario)
    {
        List<string> horas = new List<string>();
        TimeSpan intervalo = new TimeSpan(0, intervaloHorario, 0); // Intervalo de 30 minutos

        for (TimeSpan hora = horaInicio; hora <= horaFin; hora = hora.Add(intervalo))
        {
            horas.Add(hora.ToString(@"hh\:mm"));  // Formato HH:mm
        }

        return horas;
    }
}
