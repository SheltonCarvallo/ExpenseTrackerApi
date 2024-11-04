using System.Text.Json.Serialization;

namespace ModelLayer.Models;

public class Balance
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public int BankId { get; set; }
    public int StatusId { get; set; }
    public decimal Amount { get; set; }
    public DateTime BalanceCreatedDate { get; set; }
    public DateTime? BalanceUpdateDate { get; set; }
    
    //Status 
    [JsonIgnore]
    public Status? Status { get; set; }
    
    //Bank
    [JsonIgnore]
    public Bank? Bank { get; set; }
    //User
    [JsonIgnore]
    public User? User { get; set; } //Required reference navigation to principal
}
