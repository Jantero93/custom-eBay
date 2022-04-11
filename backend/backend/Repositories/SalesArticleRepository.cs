using Microsoft.EntityFrameworkCore;

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

        public async Task<List<SalesArticle>> GetAllSalesArticles()
        {
            return await _context.SalesArticles
                .Include(s => s.User)
                .Include(s => s.Location)
                .Include(s => s.Images)
                .ToListAsync();
        }
    }
}
