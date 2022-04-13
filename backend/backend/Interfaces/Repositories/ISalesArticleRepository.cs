using backend.Models;

namespace backend.Interfaces.Repositories
{
    public interface ISalesArticleRepository
    {
        public Task<SalesArticle> AddSalesArticle(SalesArticle item);
        public Task<List<SalesArticle>> GetAllSalesArticles();
        public Task<SalesArticle> GetSalesArticle(long id);
    }
}
