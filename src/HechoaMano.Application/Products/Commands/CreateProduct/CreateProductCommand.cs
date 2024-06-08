using MediatR;

namespace HechoaMano.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        int FamilyId,
        string FamilyName,
        int RegionId,
        string RegionName,
        int SubFamilyId,
        string SubFamilyName,
        int FamilyTypeId,
        string FamilyTypeName,
        int SizeId,
        string SizeName,
        decimal SellPrice,
        decimal BuyPrice
        ) : IRequest;
}
