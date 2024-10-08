using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace MauiAppSalud.Views;
public partial class PagosPage : ContentPage
    {
        private readonly WompiService _wompiService;

        public PagosPage()
        {
            InitializeComponent();
            // Inicializar el servicio de Wompi con la clave p�blica
            _wompiService = new WompiService("pub_test_htL2YwfKL1ak8McQdBFUwYRCCrpKJZ3u");
        }

        // Evento cuando se hace clic en el bot�n de procesar pago
        private async void OnProcesarPagoClicked(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos ingresados por el usuario
                string nombreTitular = NombreTitularEntry.Text;
                string numeroTarjeta = NumeroTarjetaEntry.Text;
                string cvc = CvcEntry.Text;
                string mesExpiracion = MesExpiracionEntry.Text;
                string anoExpiracion = AnoExpiracionEntry.Text;
                string emailCliente = EmailClienteEntry.Text;

                // Capturamos el monto ingresado en pesos
                string montoTexto = MontoEntry.Text;
                if (string.IsNullOrEmpty(montoTexto) || !decimal.TryParse(montoTexto, out decimal montoEnPesos))
                {
                    await DisplayAlert("Error", "Por favor ingrese un monto v�lido en pesos.", "OK");
                    return;
                }

                // Convertir el monto de pesos a centavos (multiplicar por 100)
                int montoEnCentavos = (int)(montoEnPesos * 100);

                // Generar una referencia din�mica usando la fecha y el email
                string referencia = $"Compra_{emailCliente}_{DateTime.Now.Ticks}";

                // Obtener el acceptance_token
                var acceptanceToken = await _wompiService.GetAcceptanceToken();
                Console.WriteLine("Acceptance token obtenido: " + acceptanceToken);

                // Generar el token de la tarjeta con los datos del usuario
                var token = await _wompiService.GenerateCardToken(
                    number: numeroTarjeta,
                    cvc: cvc,
                    expMonth: mesExpiracion,
                    expYear: anoExpiracion,
                    cardHolder: nombreTitular
                );

                Console.WriteLine("Token generado: " + token);

                // Llamamos al servicio para crear una transacci�n usando el token generado
                var result = await _wompiService.CreateTransaction(
                    reference: referencia,        // Referencia din�mica
                    amountInCents: montoEnCentavos, // Monto en centavos
                    currency: "COP",
                    customerEmail: emailCliente,
                    token: token,
                    acceptanceToken: acceptanceToken,
                    installments: 1
                );

                // Mostrar el resultado de la transacci�n
                await DisplayAlert("�xito", "Transacci�n exitosa: ", "OK");
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error en un cuadro de di�logo
                await DisplayAlert("Error", "Ocurri� un error: " + ex.Message, "OK");
            }
        }
    }
