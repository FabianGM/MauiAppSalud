using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class WompiService
{
    private readonly string _publicKey;
    private readonly HttpClient _httpClient;

    // Constructor para inicializar las claves públicas
    public WompiService(string publicKey)
    {
        _publicKey = publicKey;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://sandbox.wompi.co/v1/") // Entorno de pruebas sandbox
        };

        // Añadir el header de autorización con la clave pública
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_publicKey}");
    }

    // Método para obtener el acceptance_token
    public async Task<string> GetAcceptanceToken()
    {
        var response = await _httpClient.GetAsync($"merchants/{_publicKey}");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);
            return result.data.presigned_acceptance.acceptance_token; // Retorna el acceptance_token
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al obtener el acceptance_token: {response.StatusCode} - {errorResponse}");
        }
    }

    // Método para generar el token de la tarjeta
    public async Task<string> GenerateCardToken(string number, string cvc, string expMonth, string expYear, string cardHolder)
    {
        var requestPayload = new
        {
            number = number,
            cvc = cvc,
            exp_month = expMonth,
            exp_year = expYear,
            card_holder = cardHolder
        };

        var jsonRequest = JsonConvert.SerializeObject(requestPayload);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("tokens/cards", content);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);
            return result.data.id; // Retorna el ID del token generado
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al generar el token: {response.StatusCode} - {errorResponse}");
        }
    }

    // Método para crear una transacción usando el token y el acceptance_token
    public async Task<string> CreateTransaction(string reference, int amountInCents, string currency, string customerEmail, string token, string acceptanceToken, int installments = 1)
    {
        var requestPayload = new
        {
            amount_in_cents = amountInCents,
            currency = currency,
            customer_email = customerEmail,
            payment_method = new
            {
                type = "CARD",   // Usamos tarjeta de crédito
                token = token,   // El token generado
                installments = installments  // Número de cuotas, debe ser al menos 1
            },
            reference = reference,
            acceptance_token = acceptanceToken  // Acceptance token requerido
        };

        var jsonRequest = JsonConvert.SerializeObject(requestPayload);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("transactions", content);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse; // Transacción exitosa
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error en la transacción: {response.StatusCode} - {errorResponse}");
        }
    }
}
