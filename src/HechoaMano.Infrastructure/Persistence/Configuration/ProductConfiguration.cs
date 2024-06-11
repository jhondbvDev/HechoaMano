using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            Id => Id.Value,
            value => ProductId.Create(value));

        builder.OwnsOne(p => p.ProductStock, stock => 
        {
            stock.Property(s => s.Value).HasColumnName("Stock");
        });

        builder.Property(p => p.SellPrice);
        builder.Property(p => p.BuyPrice);
        builder.Property(p => p.CreatedDate);
        builder.Property(p => p.UpdatedDate);
    }
}
