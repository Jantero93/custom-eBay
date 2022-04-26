using backend.Models;

namespace backend.Interfaces.Repositories
{
    public interface ISalesArticleRepository
    {
        public Task<SalesArticle> AddSalesArticle(SalesArticle item);
        public Task<SalesArticle> GetSalesArticle(long id);
        public int GetSalesArticleCount();
        public Task<List<SalesArticle>> GetAllSalesArticles(int pageNum, int pageSize);
        public Task<List<SalesArticle>> GetSalesArticlesByUserId(long id);
    }
}
