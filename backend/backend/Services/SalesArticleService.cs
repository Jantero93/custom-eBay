using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.ViewModels;
using backend.Helpers;

namespace backend.Services
{
    public class SalesArticleService : ISalesArticleService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISalesArticleRepository _salesArticleRepository;


        public SalesArticleService(ISalesArticleRepository salesArticleRepository,
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _salesArticleRepository = salesArticleRepository;
        }


        public async Task<SalesArticle> PostSalesArticle(SaleArticleViewModel item)
        {
            var salesArticle = new SalesArticle()
            {
                Name = item.Name,
                Description = item.Description,
                ItemCondition = item.ItemCondition,
                Price = item.Price,
                User = await _userRepository.GetUserByUsername(item.Username),
                Images = new List<Image>()
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
