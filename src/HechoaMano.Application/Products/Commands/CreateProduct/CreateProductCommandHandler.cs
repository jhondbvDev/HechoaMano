using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Application.Common.Abstractions;
using MediatR;

namespace HechoaMano.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Family family = Family.Create(command.FamilyName);
        //SubFamily subFamily = SubFamily.Create(command.SubFamilyName);
        //Size size = Size.Create(command.SizeName);
        //Region region = Region.Create(command.RegionName);
        //FamilyType familyType = FamilyType.Create(command.FamilyTypeName);

        //var product = new Product(
        //                   new ProductId(Guid.NewGuid()),
        //                   family,
        //                   subFamily,
        //                   size,
        //                   region,
        //                   command.SellPrice,
        //                   command.BuyPrice
        //                   );

        //await  _productRepository.AddAsync(product);
        //await _unitOfWork.SaveChangeAsync();


    }
}
