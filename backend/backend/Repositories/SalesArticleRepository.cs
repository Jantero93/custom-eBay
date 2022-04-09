using backend.Interfaces.Repositories;
using backend.Models;

namespace backend.Repositories
{
    public class SalesArticleRepository : ISalesArticleRepository
    {
        private readonly DataContext _context;
        public SalesArticleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<SalesArticle> AddSalesArticle(SalesArticle item)
        {
            item.Created = System.DateTime.UtcNow.ToString("o");

            _context.SalesArticles.Add(item);
            await _context.SaveChangesAsync();
            
            return item;
        }
    }
}
