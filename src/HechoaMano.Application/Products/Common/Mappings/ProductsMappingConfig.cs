using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.Entities;
using Mapster;

namespace HechoaMano.Application.Products.Common.Mappings;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

public class ProductsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductResult>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Family, src => src.Family.Name)
            .Map(dest => dest.SubFamily, src => src.SubFamily.Name)
            .Map(dest => dest.Region, src => src.Region.Name)
            .Map(dest => dest.FamilyType, src => src.FamilyType.Name)
            .Map(dest => dest.Size, src => src.Size.Name)
            .Map(dest => dest.Stock, src => src.ProductStock.Value);

        config.NewConfig<Family, FamilyResult>();
        config.NewConfig<SubFamily, SubFamilyResult>();
        config.NewConfig<Size, SizeResult>();
        config.NewConfig<Region, RegionResult>();
    }
}

#pragma warning restore CS8602 // Dereference of a possibly null reference.