namespace ModelLayer.Models;

public class Expense
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public Guid UserId { get; set; }
    public int PaymentMethodId { get; set; }
    public int BankId { get; set; }
    public int CategoryId { get; set; }
    public DateTime ExpenseRegisterDate { get; set; }
    public DateTime? ExpenseUpdateDate { get; set; }
    public int StatusId { get; set; }
    //Relationships

    public User User { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public Bank Bank { get; set; } = null!;
    public Status Status { get; set; } = null!;
}