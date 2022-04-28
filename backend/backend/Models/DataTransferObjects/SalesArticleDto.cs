using backend.Helpers;

namespace backend.Models.DataTransferObjects
{
    public class SalesArticleDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public ItemCondition ItemCondition { get; set; }

        public Image? Image { get; set; } = null!;

        public int ImageCount { get; set; } = 0;

        public UserDto User { get; set; } = default!;

        public Location Location { get; set; } = default!;

        public string Created { get; set; } = String.Empty;
    }
}
