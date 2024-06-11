using HechoaMano.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.ToTable("Sizes");
        builder.HasKey(x => x.Id);

        builder.HasMany(s => s.Products)
            .WithOne(p => p.Size)
            .HasForeignKey(p => p.SizeId)
            .OnDelete(DeleteBehavior.Restrict); ;

        builder.Metadata.FindNavigation(nameof(Size.Products))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(x => x.Id);
        builder.Property(x => x.Name);
    }
}
