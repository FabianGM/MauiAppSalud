using MauiAppSalud.Views;

namespace MauiAppSalud
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Definir rutas de navegación
            Routing.RegisterRoute(nameof(PerfilProfesionalesPage), typeof(PerfilProfesionalesPage));

            // Establecer PerfilProfesionalesPage como la pagina inicial
            Items.Add(new ShellContent
            {
                Content = new PerfilProfesionalesPage()
            });

            // Registrar la ruta de navegacion
            Routing.RegisterRoute("detallesProfesional", typeof(DetallesProfesionalPage));
            Routing.RegisterRoute("citasPacientes", typeof(CitasPacientesPage));
            Routing.RegisterRoute("datosCitaPaciente", typeof(DatosCitaMedica));
            Routing.RegisterRoute("pagos", typeof(PagosPage));
        }
    }
}
