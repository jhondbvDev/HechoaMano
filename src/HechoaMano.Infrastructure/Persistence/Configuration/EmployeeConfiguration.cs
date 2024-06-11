using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HechoaMano.Infrastructure.Persistence.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id).HasConversion(
            Id => Id.Value,
            value => UserId.Create(value));
        builder.Property(c => c.Name).HasMaxLength(100);
        builder.Property(c => c.DocumentId).HasMaxLength(15);
        builder.Property(c => c.CreatedDate);
        builder.Property(c => c.UpdatedDate);
    }
}
