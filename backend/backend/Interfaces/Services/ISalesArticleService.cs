using backend.Models;
using backend.Models.DataTransferObjects;
using backend.Models.Misc;
using backend.Models.ViewModels;

namespace backend.Interfaces.Services
{
    public interface ISalesArticleService
    {
        public Task<SalesArticle> GetOne(long id);
        public Task<Pager<SalesArticleDto>> GetSalesArticlePage(int pageNum);
        public Task<SalesArticle> PostSalesArticle(SalesArticleFromViewModel item, User user);

    }
}
