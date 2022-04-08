using System.ComponentModel.DataAnnotations;

namespace backend.Models.ViewModels
{
    public class UserViewModel
    {
       
        [Required]
        [StringLength(30, ErrorMessage = "Username must contain 3 - 30 characters", MinimumLength = 3)]
        public string? Username { get; set; }

        [Required]
        [MaxLength (255)]
        public string? Password { get; set; }
    }
}
