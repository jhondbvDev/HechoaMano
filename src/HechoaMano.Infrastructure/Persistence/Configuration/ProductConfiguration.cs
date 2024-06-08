using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(
            Id => Id.Value,
            value => ProductId.Create(value));

        builder.OwnsOne(x => x.FamilyType, FamilyType =>
        {
            FamilyType.Property(x => x.Id).HasColumnName("FamilyTypeId");
        });

        builder.OwnsOne(x => x.Family, family =>
        {
            family.Property(x => x.Id).HasColumnName("FamilyId");
        });

        builder.OwnsOne(x => x.SubFamily, subFamily =>
        {
            subFamily.Property(x => x.Id).HasColumnName("SubFamilyId");
        });

        builder.OwnsOne(x => x.Size, size =>
        {
            size.Property(x => x.Id).HasColumnName("SizeId");
        });

        builder.OwnsOne(x => x.Region, region =>
        {
            region.Property(x => x.Id).HasColumnName("RegionId");
        });

        builder.Property(x => x.SellPrice);
        builder.Property(x => x.BuyPrice);
    }
}
