using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Products.Entities;
using HechoaMano.Domain.Products.ValueObjects;

namespace HechoaMano.Domain.Products;

public sealed class Product : AggregateRoot<ProductId>
{
    public string Name { get; }
    public FamilyType FamilyType { get; }
    public Family Family { get; }
    public SubFamily SubFamily { get; }
    public Size Size { get; }
    public Region Region { get; }
    public decimal SellPrice { get; }
    public decimal BuyPrice { get; }
    public DateTime CreatedDate { get;}
    public DateTime UpdatedDate { get; }

    private Product(
        ProductId id,
        FamilyType familyType,
        Family family,
        SubFamily subFamily,
        Size size,
        Region region,
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
            ProductId.CreateUnique(),
            familyType,
            family,
            subFamily,
            size,
            region,
            sellPrice,
            buyPrice,
            DateTime.Now,
            DateTime.Now);
    }
}
