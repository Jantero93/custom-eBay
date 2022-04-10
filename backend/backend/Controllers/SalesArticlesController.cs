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
        private readonly ISalesArticleService _itemService;

        public SalesArticlesController(ISalesArticleService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> PostSalesArticle([FromForm] SaleArticleViewModel item)
        {
            User? user = HttpContext.Items["User"] as User;

            if (user == null)
            {
                return Unauthorized();
            }

            await _itemService.PostSalesArticle(item, user);
            return Ok();
        }

    }
}
