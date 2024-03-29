﻿using OnlineMarketPlace.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
        Task<Product> FindProductByIdAsync(int id);
        void UpdateProductAsync(Product product);
        void Remove(Product product);
    }
}
