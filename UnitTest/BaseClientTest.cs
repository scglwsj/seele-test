using Castle.Core.Configuration;
using ConsighmentService.Clients;
using Newtonsoft.Json;
using NSubstitute;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTest;

public abstract class BaseClientTest
{

    protected IHttpClientFactory GetHttpClientFactory(HttpStatusCode statusCode, object responseBody)
    {
        var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
        var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
        {
            StatusCode = statusCode,
            Content = new StringContent(JsonConvert.SerializeObject(responseBody), Encoding.UTF8, "application/json")
        });

        var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

        httpClientFactoryMock.CreateClient().Returns(fakeHttpClient);

        return httpClientFactoryMock;


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
