using backend.Models;
using backend.Models.Misc;
using backend.Models.ViewModels;

namespace backend.Interfaces.Services
{
    public interface ISalesArticleService
    {
        public Task<SalesArticle> GetOne(long id);
        public Task<Pager<SalesArticle>> GetSalesArticlePage(int pageNum);
        public Task<SalesArticle> PostSalesArticle(SaleArticleViewModel item, User user);

    }
}
