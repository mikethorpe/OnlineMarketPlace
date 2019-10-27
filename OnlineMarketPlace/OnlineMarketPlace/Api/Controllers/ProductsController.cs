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

        /// <summary>
        /// Get a list of all products
        /// </summary>
        /// <returns>A list of all products</returns>
        /// <response code="200">When the list is returned</response>
        [ProducesResponseType(200)]
        [HttpGet("products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productsService.ListAsync();
            var productViewDtos = products.Select(p =>
                _mapper.MapProductToViewModel(p))
                .ToList();

            return Ok(productViewDtos);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <returns>The product with matching id</returns>
        /// <param name="id">The product's id</param>
        /// <response code="200">If the product is returned</response>
        /// <response code="404">If the product is not found</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productsService.FindProductByIdAsync(id);
            if (product == null) return NotFound();

            var productViewDto = _mapper.MapProductToViewModel(product);
            return Ok(productViewDto);
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <response code="200">If the product has been created</response>
        [ProducesResponseType(200)]
        [HttpPost("product")]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateUpdateProductDto createUpdateProductDto)
        {
            var product = _mapper.MapCreateUpdateDtoToProduct(createUpdateProductDto);
            await _productsService.CreateProductAsync(product);
            return Ok();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">The product's id</param>
        /// <response code="200">If the product is updated</response>
        /// <response code="404">If the product is not found</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("product/{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromForm] CreateUpdateProductDto createUpdateProductDto)
        {
            var product = _mapper.MapCreateUpdateDtoToProduct(createUpdateProductDto);
            product.Id = id;

            var response = await _productsService.UpdateProductAsync(product);

            if (response) return Ok();
            return NotFound();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">The product's id</param>
        /// <response code="200">If the product is deleted</response>
        /// <response code="404">If the product is not found</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var response = await _productsService.DeleteProductByIdAsync(id);
            if (response) return Ok();
            return NotFound();
        }
    }
}
