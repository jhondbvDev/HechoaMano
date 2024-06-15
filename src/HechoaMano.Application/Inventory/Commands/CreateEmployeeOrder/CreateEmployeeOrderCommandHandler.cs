using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products.ValueObjects;
using MediatR;

namespace HechoaMano.Application.Inventory.Commands.CreateEmployeeOrder;

public class CreateEmployeeOrderCommandHandler(IInventoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateEmployeeOrderCommand>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task Handle(CreateEmployeeOrderCommand request, CancellationToken cancellationToken)
    {
        var employeeOrder = EmployeeOrder.Create(
            UserId.Create(request.EmployeeId),
            request.Details.ConvertAll(d =>
                OrderDetail.Create(
                    ProductId.Create(d.ProductId),
                    d.Quantity,
                    d.Price
                )
            ),
            request.TotalPrice
        );

        await _repository.AddEmployeeOrderAsync(employeeOrder);

        //TODO: Add Domain Event to alter product stock

        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
