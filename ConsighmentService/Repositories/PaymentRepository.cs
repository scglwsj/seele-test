using ConsighmentService.Services.Interfaces;
using ConsighmentService.Services.Models;

namespace ConsighmentService.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private PaymentContext PaymentContext { get; }

    public PaymentRepository(PaymentContext paymentContext)
    {
        PaymentContext = paymentContext;
    }

    public Payment? FindPaymentByConsighmentId(string consighmentId)
    {
        using var context = PaymentContext;
        var result = context.Payments.FirstOrDefault(payment => payment.ConsighmentId == consighmentId);
        return result?.ToEntity();
    }
}
