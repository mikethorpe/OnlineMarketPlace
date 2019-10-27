using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Api.Dtos;
using OnlineMarketPlace.Api.Mapping;
using OnlineMarketPlace.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Controllers
{
    [Route("v1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IDtoMapper _mapper;

        public ProductsController(IProductsService productsService, IDtoMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productsService.ListAsync();
            var productViewDtos = products.Select(p =>
                _mapper.MapProductToViewModel(p))
                .ToList();

            return Ok(productViewDtos);
        }


        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productsService.FindProductByIdAsync(id);
            if (product == null) return NotFound();

            var productViewDto = _mapper.MapProductToViewModel(product);

            return Ok(productViewDto);
        }

        [HttpPost("product")]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateUpdateProductDto createUpdateProductDto)
        {
            var product = _mapper.MapCreateUpdateDtoToProduct(createUpdateProductDto);
            if (product == null) return BadRequest();

            var response = await _productsService.CreateProductAsync(product);

            if (response) return Ok();
            return BadRequest("Failed to add product");
        }

        [HttpPut("product/{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromForm] CreateUpdateProductDto createUpdateProductDto)
        {
            var product = _mapper.MapCreateUpdateDtoToProduct(createUpdateProductDto);
            product.Id = id;

            var response = await _productsService.UpdateProductAsync(product);

            if (response) return Ok();
            return NotFound();
        }
    }
}
