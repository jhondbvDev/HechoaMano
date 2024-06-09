using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Products.ValueObjects;

namespace HechoaMano.Domain.Inventory.Entities;

public sealed class OrderDetail : Entity<Guid>
{
    public ProductId ProductId { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    private OrderDetail(Guid id, ProductId productId, int quantity, decimal price) : base(id)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public static OrderDetail Create(ProductId productId, int quantity, decimal price)
    {
        return new(Guid.NewGuid(), productId, quantity, price);
    }

    public static OrderDetail Create(Guid id, ProductId productId, int quantity, decimal price) 
    {
        return new(id, productId, quantity, price);
    }
}
