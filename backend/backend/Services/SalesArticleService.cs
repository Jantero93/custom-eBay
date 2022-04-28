using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.ViewModels;
using backend.Helpers;
using backend.Models.Misc;
using backend.Models.DataTransferObjects;

namespace backend.Services
{
    public class SalesArticleService : ISalesArticleService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ISalesArticleRepository _salesArticleRepository;

        public SalesArticleService(ILocationRepository locationRepository, ISalesArticleRepository salesArticleRepository)
        {
            _locationRepository = locationRepository;
            _salesArticleRepository = salesArticleRepository;
        }

        public async Task<SalesArticle> GetOne(long id)
        {
            return await _salesArticleRepository.GetSalesArticle(id);
        }

        public async Task<Pager<SalesArticleDto>> GetSalesArticlePage(int pageNum)
        {
            const int PAGE_SIZE = 5;

            List<SalesArticle> salesArticles = await _salesArticleRepository.GetAllSalesArticles(pageNum, PAGE_SIZE);

            List<SalesArticleDto> salesArticlesDto = salesArticles.Select(s =>
                new SalesArticleDto()
                {
                    Created = s.Created,
                    Description = s.Description,
                    Id = s.Id,
                    Image = s.Images?.Count > 0 ? s.Images.ElementAt(0) : null,
                    ImageCount = s.Images?.Count ?? 0,
                    ItemCondition = s.ItemCondition,
                    Location = s.Location,
                    Name = s.Name,
                    Price = s.Price
                }
            ).ToList();

            return new Pager<SalesArticleDto>(
              salesArticlesDto,
              _salesArticleRepository.GetSalesArticleCount(),
              pageNum,
              PAGE_SIZE
              );
        }

        public async Task<SalesArticle> PostSalesArticle(SalesArticleFromViewModel item, User user)
        {
            var salesArticle = new SalesArticle()
            {
                Name = item.Name,
                Description = item.Description,
                ItemCondition = item.ItemCondition,
                Price = item.Price,
                User = user,
                Images = new List<Image>(),
                Location = await _locationRepository.GetLocationByCity(item.City)
            };

            if (item.Images != null)
            {
                salesArticle.Images = item.Images.Select(i => new Image()
                {
                    Data = Utilities.ConvertIFormFileToBytes(i),
                    Name = i.FileName,
                    Type = i.ContentType
                }).ToList();
            }

            return await _salesArticleRepository.AddSalesArticle(salesArticle);
        }
    }
}
