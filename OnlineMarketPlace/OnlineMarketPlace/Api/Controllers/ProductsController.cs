using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Api.Dtos;
using OnlineMarketPlace.Domain.Interfaces;
using OnlineMarketPlace.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Controllers
{
    [Route("v1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("products")]
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

        [HttpPost("product")]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateUpdateProductDto createProductDto)
        {
            float createProductDtoPriceFloat;
            float.TryParse(createProductDto.Price, out createProductDtoPriceFloat);
            if (createProductDtoPriceFloat == default) return BadRequest("Product price invalid");

            var product = new Product
            {
                Name = createProductDto.Name,
                Price = createProductDtoPriceFloat
            };

            var response = await _productsService.CreateProductAsync(product);

            if (response) return Ok();
            return BadRequest("Failed to add product");
        }

    }
}
