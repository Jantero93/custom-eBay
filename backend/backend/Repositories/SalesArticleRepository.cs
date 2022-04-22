using Microsoft.EntityFrameworkCore;

using backend.Helpers;
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

        public async Task<List<SalesArticle>> GetAllSalesArticles(int page = 0)
        {
            const int pageSize = 10;

            return await _context.SalesArticles
                .Include(s => s.User)
                .Include(s => s.Location)
                .Include(s => s.Images)
                .OrderByDescending(s => s.Created)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<SalesArticle> GetSalesArticle(long id)
        {
            SalesArticle? item = await _context.SalesArticles
                .Include(s => s.User)
                .Include(s => s.Images)
                .Include(s => s.Location)
                .SingleOrDefaultAsync(s => s.Id == id);

            if (item == null)
            {
                throw new AppException("No sales article by id " + id, StatusCodes.Status404NotFound);
            }

            return item;
        }

        public int GetSalesArticleCount()
        {
            return _context.SalesArticles.Count();
        }

        public async Task<List<SalesArticle>> GetSalesArticlesByUserId(long id)
        {
            return await _context.SalesArticles
                .Where(s => s.User.Id == id)
                .Include(s => s.Images)
                .Include(s => s.Location)
                .ToListAsync();
        }
    }
}
