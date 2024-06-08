using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.ValueObjects;

namespace HechoaMano.Application.Products.Abstractions;

public  interface IProductRepository
{
    Task<Product?> GetAsync(ProductId id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(ProductId id);
    Task<List<Product>> GetAll();
}
