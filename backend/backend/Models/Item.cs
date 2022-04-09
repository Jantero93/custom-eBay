using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using backend.Helpers;

namespace backend.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public ItemCondition ItemCondition { get; set; }

        public List<Image>? Images { get; set; }
    }
}
