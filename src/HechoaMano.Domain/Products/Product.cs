using HechoaMano.Domain.Common.Models;
using HechoaMano.Domain.Products.Entities;
using HechoaMano.Domain.Products.ValueObjects;

namespace HechoaMano.Domain.Products;

public class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; }
    public Guid? FamilyTypeId { get; private set; }
    public virtual FamilyType? FamilyType { get; private set; }
    public Guid FamilyId { get; private set; }
    public virtual Family Family { get; private set; }
    public Guid? SubFamilyId { get; private set; }
    public virtual SubFamily? SubFamily { get; private set; }
    public Guid? SizeId { get; private set; }
    public virtual Size? Size { get; private set; }
    public Guid RegionId { get; private set; }
    public virtual Region Region { get; private set; }
    public ProductStock ProductStock { get; private set; }
    public decimal SellPrice { get; private set; }
    public decimal BuyPrice { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Product()
    {
        
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private Product(
        ProductId id,
        string name,
        Guid? familyTypeId,
        FamilyType? familyType,
        Guid familyId,
        Family family,
        Guid? subFamilyId,
        SubFamily? subFamily,
        Guid? sizeId,
        Size? size,
        Guid regionId,
        Region region,
        ProductStock productStock,
        decimal sellPrice,
        decimal buyPrice,
        DateTime createdDate,
        DateTime updatedDate) : base(id)
    {
        Name = name;
        FamilyTypeId = familyTypeId;
        FamilyType = familyType;
        FamilyId = familyId;
        Family = family;
        SubFamilyId = subFamilyId;
        SubFamily = subFamily;
        SizeId = sizeId;
        Size = size;
        RegionId = regionId;
        Region = region;
        SellPrice = sellPrice;
        BuyPrice = buyPrice;
        ProductStock = productStock;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static Product Create(
        Guid id,
        string name,
        FamilyType familyType,
        Family family,
        SubFamily subFamily,
        Size size,
        Region region,
        decimal sellPrice,
        decimal buyPrice) 
    {
        return new(
            ProductId.Create(id),
            name,
            familyType.Id,
            familyType,
            family.Id,
            family,
            subFamily.Id,
            subFamily,
            size.Id,
            size,
            region.Id,
            region,
            ProductStock.Create(),
            sellPrice,
            buyPrice,
            DateTime.Now,
            DateTime.Now);
    }

    public static Product Create(
        Guid id,
        string name,
        Guid? familyTypeId,
        Guid familyId,
        Guid? subFamilyId,
        Guid? sizeId,
        Guid regionId,
        decimal sellPrice,
        decimal buyPrice)
    {
        return new(
            ProductId.Create(id),
            name,
            familyTypeId,
            null!,
            familyId,
            null!,
            subFamilyId,
            null!,
            sizeId,
            null!,
            regionId,
            null!,
            ProductStock.Create(),
            sellPrice,
            buyPrice,
            DateTime.Now,
            DateTime.Now);
    }

    public void AddStock(int quantity)
    {
        ProductStock = ProductStock.Create(ProductStock.Value + quantity);
    }

    public void RemoveStock(int quantity)
    {
        ProductStock = ProductStock.Create(ProductStock.Value - quantity);
    }
}