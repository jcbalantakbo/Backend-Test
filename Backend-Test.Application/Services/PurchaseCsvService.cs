using Backend_Test.Application.Interfaces;
using Backend_Test.Domain.Interfaces;
using Backend_Test.Domain.Models;
using Backend_Test.Domain.Exceptions;
using System.Text;
using Backend_Test.Utilities.Constants;

public class PurchaseCsvService : ICsvService
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IProductRepository _productRepository;

    public PurchaseCsvService(
        IPurchaseRepository purchaseRepository,
        IPersonRepository personRepository,
        IProductRepository productRepository)
    {
        _purchaseRepository = purchaseRepository;
        _personRepository = personRepository;
        _productRepository = productRepository;
    }

    public async Task<byte[]> GenerateCsvReportAsync(int id)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(id);
        if (purchase == null)
        {
            throw new BadRequestException(ErrorMessage.PurchaseNotFoundById(id));
        }


        var customer = await _personRepository.GetByIdAsync(purchase.CustomerId);
        if (customer == null)
        {
            throw new BadRequestException(ErrorMessage.CustomerNotFoundById(purchase.CustomerId));
        }

        var products = new List<Product>();
        foreach (var productId in purchase.ProductIds)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product != null)
            {
                products.Add(product);
            }
        }

        var sb = new StringBuilder();

        sb.AppendLine($"CustomerName:,{customer.Firstname} {customer.Lastname},,");
        sb.AppendLine("ProductId,Count,ProductName,Price");

        var productGroups = products
            .GroupBy(p => p.Id)
            .Select(g => new
            {
                ProductId = g.Key,
                Count = g.Count(),
                ProductName = g.First().Name,
                Price = g.First().Price
            });

        foreach (var productGroup in productGroups)
        {
            sb.AppendLine($"{productGroup.ProductId},{productGroup.Count},{productGroup.ProductName},{productGroup.Price}");
        }

        return Encoding.UTF8.GetBytes(sb.ToString());
    }
}
