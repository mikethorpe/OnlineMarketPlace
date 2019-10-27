using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productsService.ListAsync();
            var productViewModels = products.Select(p =>
                new
                {
                    p.Id,
                    p.Name,
                    Price = p.Price.ToString("n2")
                }).ToList();

            return Ok(productViewModels);
        }
    }
}
