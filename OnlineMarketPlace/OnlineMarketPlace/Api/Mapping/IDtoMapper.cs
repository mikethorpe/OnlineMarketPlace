using OnlineMarketPlace.Api.Dtos;
using OnlineMarketPlace.Domain.Models;

namespace OnlineMarketPlace.Api.Mapping
{
    public interface IDtoMapper
    {
        ViewProductDto MapProductToViewModel(Product product);
        Product MapCreateUpdateDtoToProduct(CreateUpdateProductDto createUpdateProductDto);
    }
}