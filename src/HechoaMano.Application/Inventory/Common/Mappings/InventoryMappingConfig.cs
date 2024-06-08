using HechoaMano.Domain.Inventory.Aggregates;
using Mapster;

namespace HechoaMano.Application.Inventory.Common.Mappings;

public class InventoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<InventoryControl, InventoryResult>();
        config.NewConfig<InventoryControl, DetailedInventoryResult>();

        config.NewConfig<ClientOrder, ClientOrderResult>();
        config.NewConfig<ClientOrder, DetailedClientOrderResult>();

        config.NewConfig<EmployeeOrder, EmployeeOrderResult>();
        config.NewConfig<EmployeeOrder, DetailedEmployeeOrderResult>();
    }
}
