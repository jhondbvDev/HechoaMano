using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.Entities;
using HechoaMano.Domain.Products.ValueObjects;

namespace HechoaMano.Application.Products.Abstractions;

public  interface IProductRepository
{
    #region Products

    Task<List<Product>> GetAllProductsAsync();
    Task<Product?> GetProductAsync(ProductId id);
    Task CreateProductsAsync(List<Product> products);
    void UpdateProducts(List<Product> products);

    #endregion

    Task<List<Family>> GetAllFamiliesAsync();
    Task<List<Region>> GetAllRegionsAsync();
    Task<List<Size>> GetAllSizesAsync();
    Task<List<SubFamily>> GetAllSubFamiliesAsync();
}
