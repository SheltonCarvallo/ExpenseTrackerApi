namespace ModelLayer.Models;

public class Bank
{
    public int Id { get; set; }
    public string BankName { get; set; } = string.Empty;
    public DateTime RegisterDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; } = null!;
    public ICollection<Balance>? Balances { get; set; } = new List<Balance>();
    public ICollection<Expense>? Expenses { get; set; } = new List<Expense>();
}