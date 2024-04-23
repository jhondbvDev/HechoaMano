using HechoaMano.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechoaMano.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
    }
}
