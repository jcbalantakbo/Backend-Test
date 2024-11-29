using Backend_Test.Domain.Exceptions;
using Backend_Test.Utilities.Constants;

namespace Backend_Test.Domain.Models
{
    public record Purchase
    {
        public long Id { get; init; }
        public long CustomerId { get; init; }
        public List<long> ProductIds { get; init; }

        public Purchase(long id, long customerId, List<long> productIds)
        {
            if (productIds == null || productIds.Count == 0)
            {
                throw new BadRequestException(ErrorMessage.NoProductPurchase);
            }

            Id = id;
            CustomerId = customerId;
            ProductIds = productIds;
        }
    }

}
