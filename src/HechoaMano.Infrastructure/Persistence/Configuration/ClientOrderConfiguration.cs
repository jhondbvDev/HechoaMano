using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class ClientOrderConfiguration : IEntityTypeConfiguration<ClientOrder>
{
    public void Configure(EntityTypeBuilder<ClientOrder> builder)
    {
        builder.ToTable("ClientOrders");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id);
        builder.Property(c => c.ClientId).HasConversion(
            Id => Id.Value,
            value => UserId.Create(value));

        builder.OwnsMany(c => c.Details, details =>
        {
            details.ToTable("ClientOrderDetails");
            details.WithOwner().HasForeignKey("ClientOrderId");
            details.HasKey(nameof(OrderDetail.Id), "ClientOrderId");

            details.Property(d => d.Id)
                   .ValueGeneratedNever();

            details.Property(d => d.ProductId).HasConversion(
                    Id => Id.Value,
                    value => ProductId.Create(value));

            details.Property(d => d.Quantity);
            details.Property(d => d.Price);

        });

        builder.Metadata.FindNavigation(nameof(ClientOrder.Details))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(c => c.TotalPrice);
        builder.Property(c => c.CreatedDate);
    }
}
