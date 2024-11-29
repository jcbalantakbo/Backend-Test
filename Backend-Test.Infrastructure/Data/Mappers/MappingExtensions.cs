using Backend_Test.Domain.Models;
using Backend_Test.Infrastructure.Entities;

namespace Backend_Test.Infrastructure.Data.Mappers
{
    public static class MappingExtensions
    {
        public static Person ToDomainModel(this PersonEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "PersonEntity cannot be null");

            return new Person(
                entity.Id,
                entity.Firstname,
                entity.Lastname,
                entity.YearOfBirth
            );
        }

        public static PersonEntity ToEntityModel(this Person domainModel)
        {
            if (domainModel == null)
                throw new ArgumentNullException(nameof(domainModel), "Person cannot be null");

            return new PersonEntity
            {
                Id = domainModel.Id,
                Firstname = domainModel.Firstname,
                Lastname = domainModel.Lastname,
                YearOfBirth = domainModel.YearOfBirth
            };
        }

        public static Product ToDomainModel(this ProductEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "ProductEntity cannot be null");

            return new Product(
                entity.Id,
                entity.Name,
                entity.Type,
                entity.Price
            );
        }

        public static ProductEntity ToEntityModel(this Product domainModel)
        {
            if (domainModel == null)
                throw new ArgumentNullException(nameof(domainModel), "Product cannot be null");

            return new ProductEntity
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                Type = domainModel.Type,
                Price = domainModel.Price
            };
        }

        public static Purchase ToDomainModel(this PurchaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "PurchaseEntity cannot be null");

            return new Purchase(
                entity.Id,
                entity.CustomerId,
                entity.ProductIds
            );
        }

        public static PurchaseEntity ToEntityModel(this Purchase domainModel)
        {
            if (domainModel == null)
                throw new ArgumentNullException(nameof(domainModel), "Purchase cannot be null");

            return new PurchaseEntity
            {
                Id = domainModel.Id,
                CustomerId = domainModel.CustomerId,
                ProductIds = domainModel.ProductIds
            };
        }
    }
}
