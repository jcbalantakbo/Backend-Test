using Backend_Test.Application.Interfaces;
using Backend_Test.Domain.Interfaces;
using Backend_Test.Domain.Models;

namespace Backend_Test.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return _purchaseRepository.GetAllAsync();
        }

        public Task<Purchase> GetByIdAsync(int id)
        {
            return _purchaseRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Purchase>> GetByCustomerIdAsync(int customerId)
        {
            return _purchaseRepository.GetByCustomerIdAsync(customerId);
        }

        public Task AddAsync(Purchase purchase)
        {
            return _purchaseRepository.AddAsync(purchase);
        }

        public Task UpdateAsync(Purchase purchase)
        {
            return _purchaseRepository.UpdateAsync(purchase);
        }

        public Task DeleteAsync(int id)
        {
            return _purchaseRepository.DeleteAsync(id);
        }
    }
}
