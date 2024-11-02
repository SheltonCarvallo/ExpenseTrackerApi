namespace ModelLayer.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime RegisterDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int StatusId { get; set; }
    //Navigation Properties are used to reference the related entity 
    //It can be defined on the principal or dependent entity
   // public Status? Status { get; set; } // Reference navigation property
}