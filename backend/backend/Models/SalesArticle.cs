using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using backend.Helpers;

namespace backend.Models
{
    [Table("sale_articles")]
    public class SalesArticle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public ItemCondition ItemCondition { get; set; }

        public ICollection<Image> Images { get; set; } = default!;

        [Required]
        public User User { get; set; } = default!;

        public Location Location { get; set; } = default!;

        public string Created { get; set; } = String.Empty;
    }
}
