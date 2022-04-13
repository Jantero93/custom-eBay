using backend.Models;
using backend.Models.ViewModels;

namespace backend.Interfaces.Services
{
    public interface ISalesArticleService
    {
        public Task<List<SalesArticle>> GetAll();
        public Task<SalesArticle> GetOne(long id);
        public Task<SalesArticle> PostSalesArticle(SaleArticleViewModel item, User user);
    }
}
