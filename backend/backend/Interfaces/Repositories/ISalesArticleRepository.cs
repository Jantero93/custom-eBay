using backend.Models;

namespace backend.Interfaces.Repositories
{
    public interface ISalesArticleRepository
    {
        public Task<SalesArticle> AddSalesArticle(SalesArticle item);
    }
}
