﻿using System.ComponentModel.DataAnnotations;

using backend.Helpers;

namespace backend.Models.ViewModels
{
    public class SaleArticleViewModel
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Range(0.0, Int32.MaxValue)]
        public decimal? Price { get; set; }

        [Required]
        public ItemCondition ItemCondition { get; set; }

        [Required]
        public string City { get; set; } = String.Empty;

        public List<IFormFile>? Images { get; set; }
    }
}
