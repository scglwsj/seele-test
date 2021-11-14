using ConsighmentService.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace UnitTest
{
    public class PaymentRepositoryTest
    {
        private readonly PaymentRepository paymentRepository;
        private readonly PaymentContext paymentContext;

        public PaymentRepositoryTest()
        {
            var dbOptions = new DbContextOptionsBuilder<PaymentContext>().UseInMemoryDatabase("Payment").Options;
            paymentContext = new PaymentContext(dbOptions);
            paymentRepository = new PaymentRepository(paymentContext);
        }

        [Fact]
        public void Should_return_the_payment_when_payment_is_exist_in_database()
        {
            const string consighmentId = "1";
            paymentContext.Payments.Add(
                    new PaymentDo() { Id = 1, ConsighmentId = consighmentId, CreatedAt = DateTime.Now, Amount = 200 });
            paymentContext.SaveChanges();

            var payment = paymentRepository.FindPaymentByConsighmentId(consighmentId)!;

            Assert.Equal(consighmentId, payment.ConsighmentId);
        }
    }
}
