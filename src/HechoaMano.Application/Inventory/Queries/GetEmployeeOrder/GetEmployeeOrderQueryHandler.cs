using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Domain.Inventory.Aggregates;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetEmployeeOrder;

public class GetEmployeeOrderQueryHandler(
    IInventoryRepository repository,
    IEmployeeRepository employeeRepository,
    IProductRepository productRepository) : IRequestHandler<GetEmployeeOrderQuery, DetailedEmployeeOrderResult>
{
    private readonly IInventoryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IEmployeeRepository _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

    public async Task<DetailedEmployeeOrderResult> Handle(GetEmployeeOrderQuery request, CancellationToken cancellationToken)
    {
        var employeeOrder = await _repository.GetEmployeeOrderAsync(request.OrderId) ?? throw new RecordNotFoundException(request.OrderId.ToString());
        var employeeData = await _employeeRepository.GetAsync(employeeOrder.EmployeeId) ?? throw new RecordNotFoundException(request.OrderId.ToString());

        //TODO: GetProduct Name per detail

        return employeeOrder.Adapt<DetailedEmployeeOrderResult>();
    }
}
