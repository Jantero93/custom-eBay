using Microsoft.AspNetCore.Mvc;

using backend.Interfaces.Services;
using backend.Models;
using backend.Models.Misc;
using backend.Models.ViewModels;
using backend.Models.DataTransferObjects;

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
        public async Task<ActionResult<Pager<SalesArticleDto>>> GetSalesArticlesPage([FromQuery(Name = "page")] int page)
        {
            if (page <= 0)
            {
                return BadRequest();
            }

            return await _salesArticleService.GetSalesArticlePage(page);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesArticle>> GetSaleArticle(long id)
        {
            return await _salesArticleService.GetOne(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostSalesArticle([FromForm] SalesArticleFromViewModel item)
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
