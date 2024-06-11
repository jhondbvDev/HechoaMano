using HechoaMano.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class FamilyTypeConfiguration : IEntityTypeConfiguration<FamilyType>
{
    public void Configure(EntityTypeBuilder<FamilyType> builder)
    {
        builder.ToTable("FamilyTypes");
        builder.HasKey(x => x.Id);

        builder.HasMany(f => f.Products)
            .WithOne(p => p.FamilyType)
            .HasForeignKey(p => p.FamilyTypeId)
            .OnDelete(DeleteBehavior.Restrict); ;

        builder.Metadata.FindNavigation(nameof(FamilyType.Products))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
    }
}
