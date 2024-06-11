using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id).HasConversion(
            Id => Id.Value,
            value => UserId.Create(value));
        builder.Property(c => c.Name).HasMaxLength(100);
        builder.Property(c => c.DocumentId).HasMaxLength(15);

        builder.OwnsOne(c => c.ContactInfo, contactInfo =>
        {
            contactInfo.Property(c => c.Address).HasColumnName("Address");
            contactInfo.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");
            contactInfo.Property(c => c.City).HasColumnName("City");
        });

        builder.Property(c => c.ShopName).HasMaxLength(100);
        builder.Property(c => c.Discount);
        builder.Property(c => c.CreatedDate);
        builder.Property(c => c.UpdatedDate);
    }
}
