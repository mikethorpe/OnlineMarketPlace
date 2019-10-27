using Microsoft.EntityFrameworkCore;
using OnlineMarketPlace.Domain.Interfaces;
using OnlineMarketPlace.Domain.Models;
using OnlineMarketPlace.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly OnlineMarketPlaceContext _context;

        public ProductsRepository(OnlineMarketPlaceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
