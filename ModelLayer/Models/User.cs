using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ModelLayer.Models;

public class User
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = string.Empty;
    
    public string Username { get; set; } = string.Empty;
    public string? Email { get; set; }
    public DateTime UserRegisterDate { get; set; }
    public DateTime? UserUpdateDate { get; set; }
    public int StatusId { get; set; }
    //Navigation Properties are used to reference the related entity 
    //It can be defined on the principal or dependent entity
    [JsonIgnore]
    public Status? Status { get; set; } // Reference navigation property

    public ICollection<Balance>? Balances { get; set; } = new List<Balance>();
    public ICollection<Expense>? Expenses { get; set; } = new List<Expense>();
    
}