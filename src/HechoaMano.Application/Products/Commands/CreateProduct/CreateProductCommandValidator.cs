using FluentValidation;

namespace HechoaMano.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.FamilyId).NotEmpty();
            RuleFor(x => x.FamilyName).NotEmpty();
            RuleFor(x => x.RegionId).NotEmpty();
            RuleFor(x => x.RegionName).NotEmpty();
            RuleFor(x => x.SubFamilyId).NotEmpty();
            RuleFor(x => x.SubFamilyName).NotEmpty();
            RuleFor(x => x.FamilyTypeName).NotEmpty();
            RuleFor(x => x.SizeId).NotEmpty();
            RuleFor(x => x.SizeName).NotEmpty();
            RuleFor(x => x.SellPrice).NotEmpty();
            RuleFor(x => x.BuyPrice).NotEmpty();
        }
    }
}