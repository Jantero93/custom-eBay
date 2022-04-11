using backend.Models;
using backend.Models.ViewModels;

namespace backend.Interfaces.Services
{
    public interface ISalesArticleService
    {
        public Task<SalesArticle> PostSalesArticle(SaleArticleViewModel item, User user);
        public Task<List<SalesArticle>> GetAll();
    }
}
