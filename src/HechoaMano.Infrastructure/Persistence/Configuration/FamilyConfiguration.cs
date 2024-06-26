﻿using HechoaMano.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class FamilyConfiguration : IEntityTypeConfiguration<Family>
{
    public void Configure(EntityTypeBuilder<Family> builder)
    {
        builder.ToTable("Families");
        builder.HasKey(x => x.Id);

        builder.HasMany(f => f.Products)
            .WithOne(p => p.Family)
            .HasForeignKey(p => p.FamilyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Metadata.FindNavigation(nameof(Family.Products))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
    }
}
