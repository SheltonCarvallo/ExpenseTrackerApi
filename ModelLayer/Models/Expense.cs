using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ModelLayer.Models;

public class Expense
{
    public Guid Id { get; set; }

    [Range(0, double.MaxValue, MinimumIsExclusive = true ,ErrorMessage = "Please enter a valid decimal number and greater than 0")] //This way the user can't register a $0 expense 
    public decimal Amount { get; set; } 

    [Required(ErrorMessage = "You must enter the User ID")]
    public Guid UserId { get; set; } 

    public int PaymentMethodId { get; set; }

    public int BankId { get; set; }
    public int CategoryId { get; set; }
    public DateTime ExpenseRegisterDate { get; set; }
    public DateTime? ExpenseUpdateDate { get; set; }

    [Required(ErrorMessage = "You must specify the Status ID")]
    public int StatusId { get; set; }

    //Relationships
    [JsonIgnore]
    public User? User { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
    [JsonIgnore]
    public PaymentMethod? PaymentMethod { get; set; } 
    [JsonIgnore]
    public Bank? Bank { get; set; } 
    [JsonIgnore]
    public Status? Status { get; set; }  
}