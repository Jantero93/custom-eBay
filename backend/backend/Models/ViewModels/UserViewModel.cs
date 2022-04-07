using System.ComponentModel.DataAnnotations;

namespace backend.Models.ViewModels;

public class UserViewModel
{
    [Required]
    [MaxLength(255)]
    public string? Username;

    [Required]
    [MaxLength(255)]
    public string? Password;
}
