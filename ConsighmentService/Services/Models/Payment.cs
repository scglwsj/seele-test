namespace ConsighmentService.Services.Models;

public record class Payment
{
    public Payment(string consighmentId, DateTime createdAt, decimal amount)
    {
        ConsighmentId = consighmentId;
        CreatedAt = createdAt;
        Amount = amount;
    }

    public string ConsighmentId { get; init; }
    public DateTime CreatedAt { get; init; }
    public decimal Amount { get; init; }
}
