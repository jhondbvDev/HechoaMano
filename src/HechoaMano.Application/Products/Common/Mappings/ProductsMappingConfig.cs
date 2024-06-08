using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.Entities;
using Mapster;

namespace HechoaMano.Application.Products.Common.Mappings;

public class ProductsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductResult>();
        config.NewConfig<Family, FamilyResult>();
        config.NewConfig<SubFamily, SubFamilyResult>();
        config.NewConfig<Size, SizeResult>();
        config.NewConfig<Region, RegionResult>();
    }
}
