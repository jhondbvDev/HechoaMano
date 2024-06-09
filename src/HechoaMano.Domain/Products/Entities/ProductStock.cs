using HechoaMano.Domain.Common.Models;

namespace HechoaMano.Domain.Products.Entities;

public sealed class ProductStock : Entity<Guid>
{
    public int Quantity { get; }

    private ProductStock(Guid id, int quantity) : base(id) => Quantity = quantity;

    public static ProductStock Create(Guid id, int quantity)
    {
        return new ProductStock(id, quantity);
    }
}
