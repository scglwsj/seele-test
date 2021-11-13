using ConsighmentService.Clients;
using ConsighmentService.Services.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NSubstitute;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest;

public class TransferClientTest
{
    private const string transferUrl = "http://test/url";

    [Fact]
    public void Should_return_success_when_call_payment_ok()
    {
        TransferClient client = StubResponse(HttpStatusCode.OK, new { success = true });

        var result = client.Transfer(new Transfer(20, "id 为 1 的拍卖的佣金"));

        Assert.True(result.Success);
    }

    protected static TransferClient StubResponse(HttpStatusCode statusCode, object responseBody)
    {
        var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
        var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
        {
            StatusCode = statusCode,
            Content = new StringContent(JsonConvert.SerializeObject(responseBody), Encoding.UTF8, "application/json")
        });

        var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

        httpClientFactoryMock.CreateClient().Returns(fakeHttpClient);

        var configuration = Substitute.For<IConfiguration>();
        configuration["TransferService:Url"].Returns(transferUrl);

        return new TransferClient(httpClientFactoryMock, configuration);
    }

    internal class FakeHttpMessageHandler : DelegatingHandler
    {
        private readonly HttpResponseMessage fakeResponse;

        public FakeHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            fakeResponse = responseMessage;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(fakeResponse);
        }
    }
}

