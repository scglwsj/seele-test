using Microsoft.EntityFrameworkCore;

namespace ConsighmentService.Repositories;

public class PaymentContext : DbContext
{
    public DbSet<PaymentDo> Payments { get; set; }

#pragma warning disable CS8618
    public PaymentContext(DbContextOptions options) : base(options) { }
#pragma warning restore CS8618
}
