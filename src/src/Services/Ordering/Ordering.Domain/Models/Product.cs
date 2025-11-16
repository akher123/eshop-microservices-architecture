
namespace Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; } = default!;

    public static Product Create(ProductId prodctId, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product= new Product()
        {
            Id = prodctId,
            Name = name,
            Price = price
        };

        return product;
    }
}
