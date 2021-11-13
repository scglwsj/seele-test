using ConsighmentService.Clients.DO;
using ConsighmentService.Services.Interfaces;
using ConsighmentService.Services.Models;
using System.Text.Json;

namespace ConsighmentService.Clients
{
    public class TransferClient : ITransferClient
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public TransferClient(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient.CreateClient();
            this.httpClient.BaseAddress = new Uri(configuration["TransferService:Url"]);
            options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }

        public TransferResponse Transfer(Transfer transfer)
        {
            var response = httpClient.PostAsJsonAsync("/payment/transfers", transfer).Result!;

            return response.Content.ReadFromJsonAsync<TransferResponse>().Result!;
        }
    }
}
