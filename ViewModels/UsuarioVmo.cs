using MauiAppSalud.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiAppSalud.ViewModels
{
    public class UsuarioVmo
    {
        private string nombre;
        private string correoElectronico;
        private string clave;

        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        public string CorreoElectronico
        {
            get => correoElectronico;
            set => SetProperty(ref correoElectronico, value);
        }

        public string Clave
        {
            get => clave;
            set => SetProperty(ref clave, value);
        }

        public ObservableCollection<UsuarioMod> Usuarios { get; } = new ObservableCollection<UsuarioMod>();

        public ICommand CrearUsuarioCommand { get; }

        public UsuarioVmo() => CrearUsuarioCommand = new Command(OnCrearUsuario);

        private void OnCrearUsuario()
        {
            Usuarios.Add(new UsuarioMod
            {
                Nombre = Nombre,
                CorreoElectronico = CorreoElectronico,
                Clave = Clave
            });

            // Limpiar campos
            Nombre = string.Empty;
            CorreoElectronico = string.Empty;
            Clave = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
