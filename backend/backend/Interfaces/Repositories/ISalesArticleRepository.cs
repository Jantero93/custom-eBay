﻿using backend.Models;

namespace backend.Interfaces.Repositories
{
    public interface ISalesArticleRepository
    {
        public Task<SalesArticle> AddSalesArticle(SalesArticle item);
        public Task<List<SalesArticle>> GetAllSalesArticles(int page = 0);
        public Task<SalesArticle> GetSalesArticle(long id);
        public Task<List<SalesArticle>> GetSalesArticlesByUserId(long id);
        public int GetSalesArticleCount();
    }
}
