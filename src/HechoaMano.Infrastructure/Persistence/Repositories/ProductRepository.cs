using HechoaMano.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Product product)=> await  _context.Products.AddAsync(product);

        public Task DeleteAsync(ProductId id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll() => await _context.Products.ToListAsync();

        public async Task<Product?> GetAsync(ProductId id) => await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
