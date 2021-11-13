using ConsighmentService.Services.Models;

namespace ConsighmentService.Services.Interfaces;

public interface IPaymentRepository
{
    Payment? FindPaymentByConsighmentId(string consighmentId);
}
