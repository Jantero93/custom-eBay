using Microsoft.AspNetCore.Mvc;

using backend.Interfaces.Services;
using backend.Models.ViewModels;
using backend.Models;

namespace backend.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesArticlesController : ControllerBase
    {
        private readonly ISalesArticleService _salesArticleService;

        public SalesArticlesController(ISalesArticleService itemService)
        {
            _salesArticleService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesArticle>>> GetSalesArticles()
        {
            return await _salesArticleService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesArticle>> GetSaleArticle(long id)
        {
            return await _salesArticleService.GetOne(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostSalesArticle([FromForm] SaleArticleViewModel item)
        {
            User? user = HttpContext.Items["User"] as User;

            if (user == null)
            {
                return Unauthorized();
            }

            await _salesArticleService.PostSalesArticle(item, user);
            return Ok();
        }
    }
}
