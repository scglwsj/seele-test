namespace ConsighmentService.Services;

public class CommissionService
{
    public virtual decimal CalculateCommission(decimal total)
    {
        return total / 10;
    }
}
