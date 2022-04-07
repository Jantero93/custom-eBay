using System.ComponentModel.DataAnnotations;

namespace backend.Models.DataTransferObjects
{
    public class UserDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
