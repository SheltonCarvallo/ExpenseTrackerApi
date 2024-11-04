namespace ModelLayer.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public string PaymentMethodName { get; set; } = string.Empty;
    public DateTime PaymentMethodRegisterDate { get; set; }
    public DateTime? PaymentMethodModifiedDate { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

}