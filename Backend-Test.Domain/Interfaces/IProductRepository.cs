using Backend_Test.Domain.Models;

namespace Backend_Test.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task DeleteAsync(long id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long id);
        Task UpdateAsync(Product product);
    }
}
