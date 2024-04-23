using HechoaMano.Domain.Entities;
using HechoaMano.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(
                Id => Id.Value,
                value => new ProductId(value));

            //builder.OwnsOne(x => x.Family,family => {
            //    family.Property(x => x.Id).HasColumnName("FamilyId");
            //});
            //builder.OwnsOne(x => x.SubFamily, subFamily =>
            //{
            //    subFamily.Property(x => x.Name).HasColumnName("SubFamily");
            //});
            //builder.Property(x => x.Name).HasColumnName("Name");
            //builder.Property(x => x.Description).HasColumnName("Description");
            //builder.Property(x => x.Price).HasColumnName("Price");
            //builder.Property(x => x.Stock).HasColumnName("Stock");
            //builder.Property(x => x.Image).HasColumnName("Image");
            //builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt");
            //builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt");

        }
    }
}
