using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("images")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

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
