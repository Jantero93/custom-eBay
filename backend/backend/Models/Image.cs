using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Image
    {
        [Required]
        public byte[]? Data { get; set; }

        [Required(ErrorMessage = "File name required")]
        [MaxLength(256)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "File extension required")]
        [MaxLength(32)]
        public string? Type { get; set; }
    }
}
