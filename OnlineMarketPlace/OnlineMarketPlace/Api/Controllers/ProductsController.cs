using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Api.Dtos;
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

            var productViewDtos = products.Select(p =>
                new ViewProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString("n2")
                }).ToList();

            return Ok(productViewDtos);
        }
    }
}
