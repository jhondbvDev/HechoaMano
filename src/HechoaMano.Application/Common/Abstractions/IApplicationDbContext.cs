using HechoaMano.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Application.Common.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; set; }
    Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
}
