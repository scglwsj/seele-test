using ConsighmentService.Services.Interfaces;
using ConsighmentService.Services.Models;

namespace ConsighmentService.Services;

public class ConsighmentBussinessService
{
    private readonly CommissionService commissionService;
    private readonly IPaymentRepository paymentRepository;
    private readonly ITransferClient transferClient;

    public ConsighmentBussinessService(CommissionService commissionService, IPaymentRepository paymentRepository, ITransferClient transferClient)
    {
        this.commissionService = commissionService;
        this.paymentRepository = paymentRepository;
        this.transferClient = transferClient;
    }

    public Consighment GetConsighment(string id)
    {
        return new Consighment(id);
    }

    public virtual void CreateCommissionRequest(string consighmentId)
    {
        var payment = paymentRepository.FindPaymentByConsighmentId(consighmentId);
        var commission = commissionService.CalculateCommission(payment!.Amount);
        transferClient.Transfer(new Transfer(commission, $"id 为 {consighmentId} 的拍卖的佣金"));
    }
}
