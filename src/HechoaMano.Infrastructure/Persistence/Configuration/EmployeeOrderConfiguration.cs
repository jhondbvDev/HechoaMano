using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class EmployeeOrderConfiguration : IEntityTypeConfiguration<EmployeeOrder>
{
    public void Configure(EntityTypeBuilder<EmployeeOrder> builder)
    {
        builder.ToTable("EmployeeOrders");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id);
        builder.Property(c => c.EmployeeId).HasConversion(
            Id => Id.Value,
            value => UserId.Create(value));

        builder.OwnsMany(c => c.Details, details =>
        {
            details.ToTable("EmployeeOrderDetails");
            details.WithOwner().HasForeignKey("EmployeeOrderId");
            details.HasKey(nameof(OrderDetail.Id), "EmployeeOrderId");

            details.Property(d => d.Id)
                   .ValueGeneratedNever();

            details.Property(d => d.ProductId).HasConversion(
                    Id => Id.Value,
                    value => ProductId.Create(value));

            details.Property(d => d.Quantity);
            details.Property(d => d.Price);

        });

        builder.Metadata.FindNavigation(nameof(EmployeeOrder.Details))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(c => c.TotalPrice);
        builder.Property(c => c.CreatedDate);
    }
}
