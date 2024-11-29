using Backend_Test.Domain.Interfaces;
using Backend_Test.Domain.Models;
using Backend_Test.Infrastructure.Data.Mappers;

namespace Backend_Test.Infrastructure.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly Data.Data _data;

        public PurchaseRepository(Data.Data data)
        {
            _data = data;
        }

        public Task AddAsync(Purchase purchase)
        {
            _data.Purchases.Add(purchase.ToEntityModel());
            return Task.CompletedTask;
        }

        public Task DeleteAsync(long id)
        {
            var purchaseToRemove = _data.Purchases.FirstOrDefault(p => p.Id == id);
            if (purchaseToRemove != null)
            {
                _data.Purchases.Remove(purchaseToRemove);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Purchase>> GetAllAsync()
        {
            var purchases = _data.Purchases
                .Select(purchaseEntity => purchaseEntity.ToDomainModel())
                .ToList();

            return Task.FromResult(purchases.AsEnumerable());
        }

        public Task<Purchase> GetByIdAsync(long id)
        {
            var purchaseEntity = _data.Purchases.FirstOrDefault(p => p.Id == id);

            return Task.FromResult(purchaseEntity?.ToDomainModel());
        }

        public Task<IEnumerable<Purchase>> GetByCustomerIdAsync(int customerId)
        {
            var purchases = _data.Purchases
                .Where(p => p.CustomerId == customerId)
                .Select(purchaseEntity => purchaseEntity.ToDomainModel())
                .ToList();

            return Task.FromResult(purchases.AsEnumerable());
        }

        public Task UpdateAsync(Purchase purchase)
        {
            var purchaseEntity = _data.Purchases.FirstOrDefault(p => p.Id == purchase.Id);
            if (purchaseEntity != null)
            {
                purchaseEntity.CustomerId = purchase.CustomerId;
                purchaseEntity.ProductIds = purchase.ProductIds.ToList();
            }

            return Task.CompletedTask;
        }
    }
}
