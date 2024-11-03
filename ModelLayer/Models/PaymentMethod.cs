namespace ModelLayer.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public string PaymentMethodName { get; set; } = string.Empty;
    public DateTime RegisterDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; } = null!;

}