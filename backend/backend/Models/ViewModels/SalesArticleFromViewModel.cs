using System.ComponentModel.DataAnnotations;

using backend.Models.DataTransferObjects;
using backend.Helpers;

namespace backend.Models.ViewModels
{
    public class SalesArticleFromViewModel
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = String.Empty;

        [Required]
        [Range(0.0, Int32.MaxValue)]
        public decimal Price { get; set; } = 0;

        [Required]
        public ItemCondition ItemCondition { get; set; }

        [Required]
        public string City { get; set; } = default!;

        public List<IFormFile>? Images { get; set; }

        public Image? SingleImage { get; set; }

        public UserDto? User { get; set; }
    }
}
