using HechoaMano.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class SubFamilyConfiguration : IEntityTypeConfiguration<SubFamily>
{
    public void Configure(EntityTypeBuilder<SubFamily> builder)
    {
        builder.ToTable("SubFamilies");
        builder.HasKey(x => x.Id);

        builder.HasMany(s => s.Products)
            .WithOne(p => p.SubFamily)
            .HasForeignKey(p => p.SubFamilyId)
            .OnDelete(DeleteBehavior.Restrict); ;

        builder.Metadata.FindNavigation(nameof(SubFamily.Products))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(x => x.Id);
        builder.Property(x => x.Name);
    }
}
