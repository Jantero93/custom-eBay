using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using backend.Helpers;

namespace backend.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Username must contain 3 - 30 characters", MinimumLength = 3)]
        public string Username { get; set; } = String.Empty;

        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; } = String.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Max lenght 50")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max lenght 50")]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Phone]
        public string? PhoneNumber { get; set; }

        public Location? Location { get; set; }

        public UserRole Role { get; set; }

        public string? Created { get; set; }
    }
}
