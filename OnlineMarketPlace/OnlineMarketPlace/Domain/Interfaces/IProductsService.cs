using OnlineMarketPlace.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Domain.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
