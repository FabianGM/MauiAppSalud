using System.Windows.Input;

namespace MauiAppSalud.ViewModels
{
    /// <summary>
    /// ViewModel para gestionar las citas de los pacientes.
    /// </summary>
    public class CitasPacientesPageVmo
    {
        /// <summary>
        /// Comando para confirmar cita
        /// </summary>
        public ICommand ConfirmarCitaCommand { get; }

        public CitasPacientesPageVmo()
        {
            ConfirmarCitaCommand = new Command(LlenarCitaMedica);
        }

        private async void LlenarCitaMedica() 
        {
            await Shell.Current.GoToAsync("datosCitaPaciente");
        }
    }
}
