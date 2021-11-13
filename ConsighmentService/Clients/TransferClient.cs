using ConsighmentService.Clients.DO;
using ConsighmentService.Services.Interfaces;
using ConsighmentService.Services.Models;

namespace ConsighmentService.Clients
{
    public class TransferClient : ITransferClient
    {
        private readonly HttpClient httpClient;

        public TransferClient(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient.CreateClient();
            this.httpClient.BaseAddress = new Uri(configuration["TransferService:Url"]);
        }

        public TransferResponse Transfer(Transfer transfer)
        {
            return TransferAsync(transfer).Result;
        }

        private async Task<TransferResponse> TransferAsync(Transfer transfer)
        {
            var response = await httpClient.PostAsJsonAsync("/payment/transfers", transfer);
            var result = await response.Content.ReadFromJsonAsync<TransferResponse>();
            return result!;
        }
    }
}
