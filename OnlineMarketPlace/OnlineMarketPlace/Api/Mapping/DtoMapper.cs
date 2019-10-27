using OnlineMarketPlace.Api.Dtos;
using OnlineMarketPlace.Domain.Models;

namespace OnlineMarketPlace.Api.Mapping
{
    public class DtoMapper : IDtoMapper
    {
        public ViewProductDto MapProductToViewModel(Product product)
        {
           return new ViewProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString("n2")
            };
        }

        public Product MapCreateUpdateDtoToProduct(CreateUpdateProductDto createUpdateProductDto)
        {
            float createProductDtoPriceFloat;
            float.TryParse(createUpdateProductDto.Price, out createProductDtoPriceFloat);

            return new Product
            {
                Name = createUpdateProductDto.Name,
                Price = createProductDtoPriceFloat
            };
        }
    }
}
