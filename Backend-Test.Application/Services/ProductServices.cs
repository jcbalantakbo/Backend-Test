using Backend_Test.Application.Interfaces;
using Backend_Test.Domain.Interfaces;
using Backend_Test.Domain.Models;

namespace Backend_Test.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return _productRepository.GetAllAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _productRepository.GetByIdAsync(id);
        }

        public Task AddAsync(Product product)
        {
            return _productRepository.AddAsync(product);
        }

        public Task UpdateAsync(Product product)
        {
            return _productRepository.UpdateAsync(product);
        }

        public Task DeleteAsync(int id)
        {
            return _productRepository.DeleteAsync(id);
        }

    }

    
}
