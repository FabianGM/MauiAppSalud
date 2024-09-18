using MauiAppSalud.Interfaces;
using MauiAppSalud.Models;
using System.Collections.ObjectModel;

namespace MauiAppSalud.Controllers
{
    /// <summary>
    /// Controlador para manejar la logica de los profesionales.
    /// </summary>
    public class TipoAyudaController
    {
        private readonly ITipoAyuda sTipoAyuda;

        /// <summary>
        /// Constructor que inyecta el servicio de profesionales.
        /// </summary>
        public TipoAyudaController(ITipoAyuda ayuda)
        {
            sTipoAyuda = ayuda;
        }

       /// <summary>
       /// Carga los tipos de ayuda que puede tener los profesionales desde la base de datos utilizando un procedimiento almacenado.
       /// </summary>
       /// <returns>Una coleccion observable de objetos TipoAyudaMod.</returns>
        public ObservableCollection<TipoAyudaMod> ObtenerTipoAyuda(int idProfesional)
        {
            return sTipoAyuda.ObtenerServiciosPorProfesional(idProfesional);
        }
    }
}
