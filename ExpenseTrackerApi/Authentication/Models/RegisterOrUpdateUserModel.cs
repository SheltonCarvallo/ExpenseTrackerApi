using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.Authentication.Models;

public class RegisterOrUpdateUserModel
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Username is required")]
    public string Username { get; set; } = string.Empty;    
    
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
    
}