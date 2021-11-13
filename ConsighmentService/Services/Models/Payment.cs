namespace ConsighmentService.Services.Models;

public record class Payment
{
    public Payment(string id, DateTime createdAt, decimal amount)
    {
        Id = id;
        CreatedAt = createdAt;
        Amount = amount;
    }

    public string Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public decimal Amount { get; init; }
}
