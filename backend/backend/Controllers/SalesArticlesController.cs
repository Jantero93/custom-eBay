using Microsoft.AspNetCore.Mvc;

using backend.Interfaces.Services;
using backend.Models.ViewModels;

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
        public async Task<IActionResult> PostUser([FromForm] SaleArticleViewModel item)
        {
            await _itemService.PostSalesArticle(item);
            return Ok();
        }

    }
}
