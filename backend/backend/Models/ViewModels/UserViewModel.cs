using System.ComponentModel.DataAnnotations;

namespace backend.Models.ViewModels
{
    public class UserViewModel
    {

        [StringLength(30, ErrorMessage = "Username must contain 3 - 30 characters", MinimumLength = 3)]
        public string Username { get; set; } = String.Empty;

        [MaxLength(255)]
        public string? Password { get; set; }

        [MaxLength(256)]
        public string City { get; set; } = String.Empty;

        [MaxLength(255)]
        public string Email { get; set; } = String.Empty;

        [StringLength(50, ErrorMessage = "Max lenght 50")]
        public string? FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Max lenght 50")]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? PhoneNumber { get; set; }

    }
}
