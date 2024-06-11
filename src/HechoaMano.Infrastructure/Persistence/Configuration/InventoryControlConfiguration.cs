using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class InventoryControlConfiguration : IEntityTypeConfiguration<InventoryControl>
{
    public void Configure(EntityTypeBuilder<InventoryControl> builder)
    {
        builder.ToTable("InventoryControls");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id);
        builder.Property(i => i.EmployeeId).HasConversion(
            Id => Id.Value,
            value => UserId.Create(value));

        builder.OwnsMany(i => i.Details, details =>
        {
            details.ToTable("InventoryControlDetails");
            details.WithOwner().HasForeignKey("InventoryControlId");
            details.HasKey(nameof(InventoryControlDetail.Id), "InventoryControlId");

            details.Property(d => d.Id)
                   .ValueGeneratedNever();

            details.Property(d => d.ProductId).HasConversion(
                    Id => Id.Value,
                    value => ProductId.Create(value));

            details.Property(d => d.CountedQuantity);
            details.Property(d => d.SystemQuantity);

        });

        builder.Metadata.FindNavigation(nameof(InventoryControl.Details))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(c => c.CreatedDate);
    }
}
