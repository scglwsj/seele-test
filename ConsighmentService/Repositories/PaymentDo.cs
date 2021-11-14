using ConsighmentService.Services.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsighmentService.Repositories;

[Table("Payment")]
public record class PaymentDo
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string ConsighmentId { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public decimal Amount { get; set; }

    public Payment ToEntity()
    {
        return new Payment(ConsighmentId, CreatedAt, Amount);
    }
}

