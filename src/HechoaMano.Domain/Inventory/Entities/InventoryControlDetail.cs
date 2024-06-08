using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Products.ValueObjects;

namespace HechoaMano.Domain.Inventory.Entities;

public sealed class InventoryControlDetail : Entity<Guid>
{
    public ProductId ProductId { get; }
    public int CountedQuantity { get; }
    public int SystemQuantity { get; }

    private InventoryControlDetail(Guid id, ProductId productId, int countedQuantity, int systemQuantity) : base(id)
    {
        ProductId = productId;
        CountedQuantity = countedQuantity;
        SystemQuantity = systemQuantity;
    }

    public static InventoryControlDetail Create(Guid id, ProductId productId, int countedQuantity, int systemQuantity)
    {
        return new(id, productId, countedQuantity, systemQuantity);
    }
}

