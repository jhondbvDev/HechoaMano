using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using MediatR;

namespace HechoaMano.Application.Inventory.Commands.CreateInventoryControl;

public class CreateInventoryControlQueryHandler(IInventoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateInventoryControlCommand>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task Handle(CreateInventoryControlCommand request, CancellationToken cancellationToken)
    {
        var inventoryControl = InventoryControl.Create(
                UserId.Create(request.EmployeeId),
                request.Details.ConvertAll(d => 
                    InventoryControlDetail.Create(
                        ProductId.Create(d.ProductId),
                        d.CountedQuantity,
                        d.SystemQuantity
                    )
                )
        );

        await _repository.AddInventoryControlAsync(inventoryControl);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
