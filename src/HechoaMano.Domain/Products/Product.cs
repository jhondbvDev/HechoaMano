using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Products.Entities;
using HechoaMano.Domain.Products.ValueObjects;

namespace HechoaMano.Domain.Products;

public sealed class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; }
    public FamilyType FamilyType { get; private set; }
    public Family Family { get; private set; }
    public SubFamily SubFamily { get; private set; }
    public Size Size { get; private set; }
    public Region Region { get; private set; }
    public ProductStock ProductStock { get; private set; }
    public decimal SellPrice { get; private set; }
    public decimal BuyPrice { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    private Product(
        ProductId id,
        FamilyType familyType,
        Family family,
        SubFamily subFamily,
        Size size,
        Region region,
        ProductStock productStock,
        decimal sellPrice,
        decimal buyPrice,
        DateTime createdDate,
        DateTime updatedDate) : base(id)
    {
        Name = $"{family.Name} {subFamily.Name} {familyType.Name} {size.Name} {region.Name}";
        FamilyType = familyType;
        Family = family;
        SubFamily = subFamily;
        Size = size;
        Region = region;
        SellPrice = sellPrice;
        BuyPrice = buyPrice;
        ProductStock = productStock;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static Product Create(
        FamilyType familyType,
        Family family,
        SubFamily subFamily,
        Size size,
        Region region,
        decimal sellPrice,
        decimal buyPrice) 
    {
        return new(
            ProductId.Create(),
            familyType,
            family,
            subFamily,
            size,
            region,
            ProductStock.Create(),
            sellPrice,
            buyPrice,
            DateTime.Now,
            DateTime.Now);
    }
}