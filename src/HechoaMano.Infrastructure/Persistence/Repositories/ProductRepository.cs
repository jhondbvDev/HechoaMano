using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Infrastructure.Persistence.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    #region Products
    public async Task<List<Product>> GetAllProductsAsync() => 
        await _context.Products
            .Include(p => p.FamilyType)
            .Include(p => p.Family)
            .Include(p => p.SubFamily)
            .Include(p => p.Size)
            .Include(p => p.Region)
            .ToListAsync();
    public async Task<Product?> GetProductAsync(ProductId id) => await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
    public async Task CreateProductsAsync(List<Product> products) => await _context.Products.AddRangeAsync(products);
    public void UpdateProducts(List<Product> products) => _context.UpdateRange(products);
    #endregion

    public async Task<List<Family>> GetAllFamiliesAsync() => await _context.Families.ToListAsync();
    public async Task<List<Region>> GetAllRegionsAsync() => await _context.Regions.ToListAsync();
    public async Task<List<Size>> GetAllSizesAsync() => await _context.Sizes.ToListAsync();
    public async Task<List<SubFamily>> GetAllSubFamiliesAsync() => await _context.SubFamilies.ToListAsync();
}