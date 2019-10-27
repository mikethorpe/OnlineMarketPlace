using OnlineMarketPlace.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
