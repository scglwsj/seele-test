namespace ConsighmentService.Services.Models;

public record class Transfer
{
    public decimal Amout { get; init; }
    public string Commnet { get; init; }

    public Transfer(decimal amout, string commnet)
    {
        Amout = amout;
        Commnet = commnet;
    }
}
