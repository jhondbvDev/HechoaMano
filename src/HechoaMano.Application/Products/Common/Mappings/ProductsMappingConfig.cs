using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.Entities;
using Mapster;

namespace HechoaMano.Application.Products.Common.Mappings;

public class ProductsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductResult>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.FamilyName, src => src.Family.Name)
            .Map(dest => dest.SubFamilyName, src => src.SubFamily.Name)
            .Map(dest => dest.RegionName, src => src.Region.Name)
            .Map(dest => dest.FamilyTypeName, src => src.FamilyType.Name)
            .Map(dest => dest.SizeName, src => src.Size.Name)
            .Map(dest => dest.Stock, src => src.ProductStock.Value);

        config.NewConfig<Family, FamilyResult>();
        config.NewConfig<SubFamily, SubFamilyResult>();
        config.NewConfig<Size, SizeResult>();
        config.NewConfig<Region, RegionResult>();
    }
}
