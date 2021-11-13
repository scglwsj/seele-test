namespace ConsighmentService.Services.Models;

public record class Consighment
{
    public Consighment(string id)
    {
        Id = id;
    }

    public string Id { get; init; }
}
