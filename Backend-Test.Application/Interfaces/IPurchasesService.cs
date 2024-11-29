using Backend_Test.Domain.Models;

namespace Backend_Test.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetAllAsync();
        Task<Purchase> GetByIdAsync(int id);
        Task<IEnumerable<Purchase>> GetByCustomerIdAsync(int customerId);
        Task AddAsync(Purchase purchase);
        Task UpdateAsync(Purchase purchase);
        Task DeleteAsync(int id);
    }
}
