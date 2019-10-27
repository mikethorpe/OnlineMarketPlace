using OnlineMarketPlace.Domain.Interfaces;
using OnlineMarketPlace.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Domain.Services
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
            await _repo.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<Product> FindProductByIdAsync(int id)
        {
            return await _repo.FindProductByIdAsync(id);
        }

        public async Task<bool> UpdateProductAsync(Product updatedProduct)
        {
            var existingProduct = await _repo.FindProductByIdAsync(updatedProduct.Id);
            if (existingProduct == null) return false;

            // Only update the fields provided
            existingProduct.Name = updatedProduct.Name ?? existingProduct.Name;
            existingProduct.Price = updatedProduct.Price != default ? updatedProduct.Price : existingProduct.Price;

            _repo.UpdateProductAsync(existingProduct);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var existingProduct = await _repo.FindProductByIdAsync(id);
            if (existingProduct == null) return false;

            _repo.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
