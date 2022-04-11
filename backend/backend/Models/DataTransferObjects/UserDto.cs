using System.ComponentModel.DataAnnotations;

namespace backend.Models.DataTransferObjects
{
    public class UserDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Username must contain 3 - 30 characters", MinimumLength = 3)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(255)]
        public string? FirstName { get; set; }

        [MaxLength(255)]
        public string? LastName { get; set; }

        [MaxLength(255)]
        public string? PhoneNumber { get; set; }

        public Location? Location { get; set; }
    }
}
