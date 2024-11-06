using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTOs
{
    public record PutUserDTO
    {
        [Required(ErrorMessage = "Identification ID is required")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Identificatio number must be 10 digits")]
        public string IdentificationID { get; init; } = null!;

        [Required(ErrorMessage = "First name ID is required")]
        public string? FirstName { get; init; }

        [Required(ErrorMessage = "Last name ID is required")]
        public string? LastName { get; init; }

        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        public DateTime UserUpdateDate { get; init; } = DateTime.Now;
    }
}
