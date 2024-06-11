using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Products.ValueObjects;

namespace HechoaMano.Domain.Inventory.Entities;

public sealed class OrderDetail : Entity<Guid>
{
    public ProductId ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

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