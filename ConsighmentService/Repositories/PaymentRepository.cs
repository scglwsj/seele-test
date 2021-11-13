using ConsighmentService.Services.Interfaces;
using ConsighmentService.Services.Models;

namespace ConsighmentService.Repositories;

public class PaymentRepository : IPaymentRepository
{
    public Payment? FindPaymentByConsighmentId(string consighmentId)
    {
        return new Payment("1", DateTime.Now, 200);
    }
}
