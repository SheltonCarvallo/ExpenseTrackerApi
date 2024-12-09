using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTOs
{
    public record PutUserDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; init; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; init; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; init; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        public DateTime UserUpdateDate { get; init; } = DateTime.Now;
    }
}
