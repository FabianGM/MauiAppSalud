using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiAppSalud.ViewModels
{
    /// <summary>
    /// Clase base para todos los ViewModels, implementa la interfaz INotifyPropertyChanged.
    /// </summary>
    public class BaseVmo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler ?PropertyChanged;

        /// <summary>
        /// Metodo que notifica cuando una propiedad cambia.
        /// </summary>
        /// <param name="propertyName">El nombre de la propiedad que cambia.</param>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Metodo que establece una propiedad y notifica su cambio.
        /// </summary>
        /// <typeparam name="T">El tipo de la propiedad.</typeparam>
        /// <param name="backingStore">Referencia a la propiedad respaldada.</param>
        /// <param name="value">El nuevo valor.</param>
        /// <param name="propertyName">El nombre de la propiedad.</param>
        /// <returns>Verdadero si el valor cambio, de lo contrario falso.</returns>
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
