namespace ModelLayer.Models;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public List<Expense>? Expenses { get; set; } = new List<Expense>();
}