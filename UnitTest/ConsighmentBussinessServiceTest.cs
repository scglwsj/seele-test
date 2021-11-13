using Moq;
using ConsighmentService.Services;
using ConsighmentService.Services.Interfaces;
using ConsighmentService.Services.Models;
using System;
using Xunit;

namespace UnitTest;

public class ConsighmentServiceTest
{
    private readonly ConsighmentBussinessService servise;
    private readonly Mock<CommissionService> commissionService;
    private readonly Mock<IPaymentRepository> paymentRepository;
    private readonly Mock<ITransferClient> transferClient;

    public ConsighmentServiceTest()
    {
        commissionService = new Mock<CommissionService>();
        paymentRepository = new Mock<IPaymentRepository>();
        transferClient = new Mock<ITransferClient>();
        servise = new ConsighmentBussinessService(
            commissionService.Object,
            paymentRepository.Object,
            transferClient.Object);
    }

    [Fact]
    public void Should_create_commission_success()
    {
        const string ConsighmentId = "1";
        paymentRepository
            .Setup(mock => mock.FindPaymentByConsighmentId(ConsighmentId))
            .Returns(new Payment("1", DateTime.Now, 200))
            .Verifiable();
        commissionService
            .Setup(mock => mock.CalculateCommission(200))
            .Returns(20)
            .Verifiable();
        transferClient
            .Setup(mock => mock.Transfer(It.Is<Transfer>(transfer => transfer.Amout == 20)))
            .Verifiable();

        servise.CreateCommissionRequest(ConsighmentId);


        paymentRepository.VerifyAll();
        commissionService.VerifyAll();
        transferClient.VerifyAll();
    }
}
