namespace ConsighmentService.Clients.DO;

public record class TransferResponse
{
    public bool Success { get; set; }
    public string? Reason { get; set; }
}
