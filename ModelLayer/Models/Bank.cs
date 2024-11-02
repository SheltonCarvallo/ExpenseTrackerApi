namespace ModelLayer.Models;

public class Bank
{
    public int Id { get; set; }
    public string BankName { get; set; } = string.Empty;
    public DateTime RegisterDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int StatusId { get; set; }
}