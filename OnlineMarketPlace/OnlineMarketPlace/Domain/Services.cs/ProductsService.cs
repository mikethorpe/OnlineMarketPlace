using OnlineMarketPlace.Domain.Interfaces;
using OnlineMarketPlace.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Domain.Services.cs
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _repo;

        public ProductsService(IProductsRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _repo.ListAsync();
        }
    }
}
