using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.ViewModels;
using backend.Helpers;

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

        public async Task<List<SalesArticle>> GetAll()
        {
            List<SalesArticle> salesArcticles = await _salesArticleRepository.GetAllSalesArticles();

            foreach (SalesArticle article in salesArcticles)
            {
                if (article.Images?.Count > 0)
                {
                    Image firstImage = article.Images.First();
                    article.Images.Clear();
                    article.Images.Add(firstImage);
                }

                article.User.Password = null;
                article.User.Created = null;
            }

            return await _salesArticleRepository.GetAllSalesArticles();
        }

        public async Task<SalesArticle> GetOne(long id)
        {
            return await _salesArticleRepository.GetSalesArticle(id);
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
