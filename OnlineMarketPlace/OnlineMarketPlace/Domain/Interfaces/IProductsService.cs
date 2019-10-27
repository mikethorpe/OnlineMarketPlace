using OnlineMarketPlace.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Domain.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<bool> CreateProductAsync(Product product);
        Task<Product> FindProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(Product product);
    }
}
