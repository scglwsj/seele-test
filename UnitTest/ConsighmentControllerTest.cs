using Microsoft.AspNetCore.Mvc;
using Moq;
using ConsighmentService.Controllers;
using ConsighmentService.Services;
using Xunit;

namespace UnitTest;

public class ConsighmentControllerTest
{
    private readonly ConsighmentController controller;
    private readonly Mock<ConsighmentBussinessService> servise;

    public ConsighmentControllerTest()
    {
        servise = new Mock<ConsighmentBussinessService>(null, null, null);
        controller = new ConsighmentController(servise.Object);
    }

    [Fact]
    public void Should_return_201_when_call_commission()
    {
        const string ConsighmentId = "1";
        servise.Setup(mock => mock.CreateCommissionRequest(ConsighmentId)).Verifiable();

        var result = controller.CommissionRequest(ConsighmentId);

        Assert.NotNull(result);
        Assert.IsType<CreatedResult>(result);
        servise.VerifyAll();
    }
}
