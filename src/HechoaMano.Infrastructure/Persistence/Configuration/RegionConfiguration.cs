using HechoaMano.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Regions");
        builder.HasKey(x => x.Id);

        builder.HasMany(r => r.Products)
            .WithOne(p => p.Region)
            .HasForeignKey(p => p.RegionId)
            .OnDelete(DeleteBehavior.Restrict); ;

        builder.Metadata.FindNavigation(nameof(Region.Products))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(x => x.Id);
        builder.Property(x => x.Name);
    }
}
