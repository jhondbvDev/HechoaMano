using HechoaMano.Application.Inventory.Commands.CreateClientOrder;
using HechoaMano.Application.Inventory.Commands.CreateEmployeeOrder;
using HechoaMano.Application.Inventory.Commands.CreateInventoryControl;
using Mapster;

namespace HechoaMano.API.Contracts.Inventory.Mappings;

public class InventoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateClientOrderRequest, CreateClientOrderCommand>();
        config.NewConfig<CreateEmployeeOrderRequest, CreateEmployeeOrderCommand>();
        config.NewConfig<CreateInventoryControlRequest, CreateInventoryControlCommand>();
    }
}
