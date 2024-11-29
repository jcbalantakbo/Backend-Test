using Backend_Test.Domain.Interfaces;
using Backend_Test.Domain.Models;
using Backend_Test.Infrastructure.Data.Mappers;

namespace Backend_Test.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Data.Data _data;

        public ProductRepository(Data.Data data)
        {
            _data = data;
        }

        public Task AddAsync(Product product)
        {
            _data.Products.Add(product.ToEntityModel());
            return Task.CompletedTask;
        }

        public Task DeleteAsync(long id)
        {
            var productToRemove = _data.Products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                _data.Products.Remove(productToRemove);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _data.Products
                .Select(productEntity => productEntity.ToDomainModel())
                .ToList();

            return Task.FromResult(products.AsEnumerable());
        }

        public Task<Product> GetByIdAsync(long id)
        {
            var productEntity = _data.Products.FirstOrDefault(p => p.Id == id);

            return Task.FromResult(productEntity?.ToDomainModel());
        }

        public Task UpdateAsync(Product product)
        {
            var productEntity = _data.Products.FirstOrDefault(p => p.Id == product.Id);
            if (productEntity != null)
            {
                productEntity.Name = product.Name;
                productEntity.Type = product.Type;
                productEntity.Price = product.Price;
            }

            return Task.CompletedTask;
        }
    }
}
