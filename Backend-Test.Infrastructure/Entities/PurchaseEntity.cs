namespace Backend_Test.Infrastructure.Entities
{
    public class PurchaseEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public List<long> ProductIds { get; set; }
    }
}
