using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.ViewModels;
using backend.Helpers;
using backend.Models.Misc;

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

        public async Task<Pager<SalesArticle>> GetSalesArticlePage(int pageNum)
        {
            const int PAGE_SIZE = 5;

            List<SalesArticle> salesArticles = await _salesArticleRepository.GetSalesArticlesPage(pageNum, PAGE_SIZE);

            foreach (SalesArticle article in salesArticles)
            {
                if (article.Images?.Count > 0)
                {
                    article.Images = article.Images.Select((Image image, int index) =>
                         index == 0 ? image : new Image()
                    ).ToList();
                }

                article.User.Password = null;
                article.User.Created = null;
            }

            return new Pager<SalesArticle>(
                salesArticles,
                _salesArticleRepository.GetSalesArticleCount(),
                pageNum,
                PAGE_SIZE
                );
        }

        public async Task<SalesArticle> PostSalesArticle(SaleArticleViewModel item, User user)
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
