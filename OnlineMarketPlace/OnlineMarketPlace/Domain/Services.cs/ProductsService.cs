using OnlineMarketPlace.Domain.Interfaces;
using OnlineMarketPlace.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Domain.Services.cs
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsService(IProductsRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _repo.ListAsync();
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                await _repo.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Product> FindProductByIdAsync(int id)
        {
            return await _repo.FindProductByIdAsync(id);
        }
    }
}
