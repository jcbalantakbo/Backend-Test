using Backend_Test.Domain.Models;

namespace Backend_Test.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        Task AddAsync(Purchase purchase);
        Task DeleteAsync(long id);
        Task<IEnumerable<Purchase>> GetAllAsync();
        Task<Purchase> GetByIdAsync(long id);
        Task<IEnumerable<Purchase>> GetByCustomerIdAsync(int customerId);
        Task UpdateAsync(Purchase purchase);
    }
}
