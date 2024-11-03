namespace ModelLayer.Models;

public class Balance
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public int BankId { get; set; }
    public int StatusId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
    //Status 
    public Status Status { get; set; } = null!;
    
    //Bank
    public Bank Bank { get; set; } = null!;
    
    //User
    public User User { get; set; } = null!; //Required reference navigation to principal
}
