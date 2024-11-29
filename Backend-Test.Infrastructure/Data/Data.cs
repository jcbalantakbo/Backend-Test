using Backend_Test.Infrastructure.Entities;

namespace Backend_Test.Infrastructure.Data
{
    /// <summary>
    /// NOT PART OF TEST. MERELY TO SUPPLY DATA
    /// </summary>
    public class Data
    {
        // Using properties instead of public fields
        public List<PersonEntity> Persons { get; set; } = new()
        {
            new PersonEntity { Id = 1, Firstname = "John", Lastname = "Doe", YearOfBirth = 1980 },
            new PersonEntity { Id = 2, Firstname = "Jane", Lastname = "Doe", YearOfBirth = 1985 },
            new PersonEntity { Id = 3, Firstname = "Bob", Lastname = "Smith", YearOfBirth = 1990 },
            new PersonEntity { Id = 4, Firstname = "Alice", Lastname = "Johnson", YearOfBirth = 1995 },
            new PersonEntity { Id = 5, Firstname = "Mike", Lastname = "Brown", YearOfBirth = 1982 },
            new PersonEntity { Id = 6, Firstname = "Samantha", Lastname = "Davis", YearOfBirth = 1987 },
            new PersonEntity { Id = 7, Firstname = "David", Lastname = "Wilson", YearOfBirth = 1992 },
            new PersonEntity { Id = 8, Firstname = "Emily", Lastname = "Taylor", YearOfBirth = 1997 },
            new PersonEntity { Id = 9, Firstname = "Chris", Lastname = "Anderson", YearOfBirth = 1984 },
            new PersonEntity { Id = 10, Firstname = "Jessica", Lastname = "Thomas", YearOfBirth = 1989 }
        };

        public List<ProductEntity> Products { get; set; } = new()
        {
            new ProductEntity { Id = 1, Name = "Pipe Wrench", Type = "Plumbing", Price = 19.99 },
            new ProductEntity { Id = 2, Name = "Electric Drill", Type = "Electric", Price = 89.99 },
            new ProductEntity { Id = 3, Name = "Garden Hose", Type = "Gardening", Price = 15.49 },
            new ProductEntity { Id = 4, Name = "Toilet Plunger", Type = "Plumbing", Price = 7.99 },
            new ProductEntity { Id = 5, Name = "Electric Screwdriver", Type = "Electric", Price = 29.99 },
            new ProductEntity { Id = 6, Name = "Garden Shovel", Type = "Gardening", Price = 12.99 },
            new ProductEntity { Id = 7, Name = "Faucet", Type = "Plumbing", Price = 45.99 },
            new ProductEntity { Id = 8, Name = "Electric Saw", Type = "Electric", Price = 129.99 },
            new ProductEntity { Id = 9, Name = "Garden Gloves", Type = "Gardening", Price = 8.99 },
            new ProductEntity { Id = 10, Name = "Pipe Cutter", Type = "Plumbing", Price = 24.99 }
        };


        public List<PurchaseEntity> Purchases { get; set; } = new()
        {
            new PurchaseEntity { Id = 1, CustomerId = 1, ProductIds = new List<long>{ 1 } },
            new PurchaseEntity { Id = 2, CustomerId = 1, ProductIds = new List<long>{ 2 } },
            new PurchaseEntity { Id = 3, CustomerId = 1, ProductIds = new List<long>{ 3 } },
            new PurchaseEntity { Id = 4, CustomerId = 2, ProductIds = new List<long>{ 4 } },
            new PurchaseEntity { Id = 5, CustomerId = 2, ProductIds = new List<long>{ 5 } },
            new PurchaseEntity { Id = 6, CustomerId = 3, ProductIds = new List<long>{ 6 } },
            new PurchaseEntity { Id = 7, CustomerId = 7, ProductIds = new List<long>{ 7 } },
            new PurchaseEntity { Id = 8, CustomerId = 7, ProductIds = new List<long>{ 8 } },
            new PurchaseEntity { Id = 9, CustomerId = 4, ProductIds = new List<long>{ 9 } },
            new PurchaseEntity { Id = 10, CustomerId = 4, ProductIds = new List<long>{ 10 } },
            new PurchaseEntity { Id = 11, CustomerId = 4, ProductIds = new List<long>{ 4 } },
            new PurchaseEntity { Id = 12, CustomerId = 4, ProductIds = new List<long>{ 8 } },
            new PurchaseEntity { Id = 13, CustomerId = 8, ProductIds = new List<long>{ 8 } },
            new PurchaseEntity { Id = 14, CustomerId = 8, ProductIds = new List<long>{ 2 } },
            new PurchaseEntity { Id = 15, CustomerId = 5, ProductIds = new List<long>{ 1 } },
            new PurchaseEntity { Id = 16, CustomerId = 5, ProductIds = new List<long>{ 6 } },
            new PurchaseEntity { Id = 17, CustomerId = 8, ProductIds = new List<long>{ 5 } },
            new PurchaseEntity { Id = 18, CustomerId = 1, ProductIds = new List<long>{ 4 } },
            new PurchaseEntity { Id = 19, CustomerId = 2, ProductIds = new List<long>{ 6 } },
            new PurchaseEntity { Id = 20, CustomerId = 3, ProductIds = new List<long>{ 10 } },
            new PurchaseEntity { Id = 21, CustomerId = 4, ProductIds = new List<long>{ 3 } },
            new PurchaseEntity { Id = 22, CustomerId = 5, ProductIds = new List<long>{ 1 } },
            new PurchaseEntity { Id = 23, CustomerId = 1, ProductIds = new List<long>{ 6 } },
            new PurchaseEntity { Id = 24, CustomerId = 2, ProductIds = new List<long>{ 10 } },
            new PurchaseEntity { Id = 25, CustomerId = 3, ProductIds = new List<long>{ 7 } },
            new PurchaseEntity { Id = 26, CustomerId = 4, ProductIds = new List<long>{ 1 } },
            new PurchaseEntity { Id = 27, CustomerId = 5, ProductIds = new List<long>{ 6 } },
            new PurchaseEntity { Id = 28, CustomerId = 1, ProductIds = new List<long>{ 10 } },
            new PurchaseEntity { Id = 29, CustomerId = 2, ProductIds = new List<long>{ 7 } },
            new PurchaseEntity { Id = 30, CustomerId = 3, ProductIds = new List<long>{ 1 } },
            new PurchaseEntity { Id = 31, CustomerId = 4, ProductIds = new List<long>{ 6 } },
            new PurchaseEntity { Id = 32, CustomerId = 5, ProductIds = new List<long>{ 10 } },
            new PurchaseEntity { Id = 33, CustomerId = 1, ProductIds = new List<long>{ 7 } },
            new PurchaseEntity { Id = 34, CustomerId = 2, ProductIds = new List<long>{ 1 } },
            new PurchaseEntity { Id = 35, CustomerId = 3, ProductIds = new List<long>{ 6 } },
            new PurchaseEntity { Id = 36, CustomerId = 4, ProductIds = new List<long>{ 10 } },
            new PurchaseEntity { Id = 37, CustomerId = 6, ProductIds = new List<long>{ 1 } },
            new PurchaseEntity { Id = 38, CustomerId = 6, ProductIds = new List<long>{ 4 } },
            new PurchaseEntity { Id = 39, CustomerId = 6, ProductIds = new List<long>{ 7 } }
        };
    }
}
