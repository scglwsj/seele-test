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

public class TransferClientTest : BaseClientTest
{
    private const string transferUrl = "http://test/url";

    [Fact]
    public void Should_return_success_when_call_payment_ok()
    {
        TransferClient client = StubRespnse(HttpStatusCode.OK, new { success = true });

        var result = client.Transfer(new Transfer(20, "id 为 1 的拍卖的佣金"));

        Assert.True(result.Success);
    }

    private TransferClient StubRespnse(HttpStatusCode statusCode, object responseBody)
    {
        var httpClientFactoryMock = GetHttpClientFactory(statusCode, responseBody);

        var configuration = Substitute.For<IConfiguration>();
        configuration["TransferService:Url"].Returns(transferUrl);

        return new TransferClient(httpClientFactoryMock, configuration);
    }
}
