using System.ComponentModel.DataAnnotations;

using backend.Helpers;

namespace backend.Models.ViewModels
{
    public class SaleArticleViewModel
    {
        [Required]
        [MaxLength(256)]
        public string? Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Range(0.0, Int32.MaxValue)]
        public decimal? Price { get; set; }

        [Required]
        public ItemCondition ItemCondition { get; set; }

        public List<IFormFile>? Images { get; set; }

        [Required]
        public string Username { get; set; } = String.Empty;
    }
}
