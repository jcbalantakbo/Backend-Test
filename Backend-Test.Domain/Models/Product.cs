using Backend_Test.Domain.Exceptions;
using Backend_Test.Utilities.Constants;

namespace Backend_Test.Domain.Models
{
    public record Product
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public double Price { get; init; }

        public Product(long id, string name, string type, double price)
        {
            if (price < 0)
            {
                throw new BadRequestException(ErrorMessage.NegativePrice);
            }

            Id = id;
            Name = name;
            Type = type;
            Price = price;
        }
    }
}
