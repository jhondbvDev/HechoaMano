using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Employees;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products;
using Mapster;

namespace HechoaMano.Application.Inventory.Common.Mappings;

public class InventoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(InventoryControl Control, Employee Employee), InventoryResult>()
            .Map(dest => dest, src => src.Control)
            .Map(dest => dest.EmployeeName, src => src.Employee.Name);

        config.NewConfig<(InventoryControlDetail Detail, Product Product), InventoryDetailResult>()
            .Map(dest => dest, src => src.Detail)
            .Map(dest => dest.ProductId, src => src.Detail.ProductId.Value)
            .Map(dest => dest.ProductName, src => src.Product.Name);

        config.NewConfig<(ClientOrder Order, Client Client), ClientOrderResult>()
            .Map(dest => dest, src => src.Order)
            .Map(dest => dest.ClientName, src => src.Client.Name)
            .Map(dest => dest.ShopName, src => src.Client.ShopName);

        config.NewConfig<(ClientOrder Order, Client Client, List<OrderDetailResult> Details), DetailedClientOrderResult>()
            .Map(dest => dest, src => src.Order)
            .Map(dest => dest.ClientName, src => src.Client.Name)
            .Map(dest => dest.ShopName, src => src.Client.ShopName)
            .Map(dest => dest.City, src => src.Client.ContactInfo.City)
            .Map(dest => dest.Discount, src => src.Client.Discount)
            .Map(dest => dest.Details, src => src.Details);

        config.NewConfig<(EmployeeOrder Order, Employee Employee), EmployeeOrderResult>()
            .Map(dest => dest, src => src.Order)
            .Map(dest => dest.EmployeeName, src => src.Employee.Name);

        config.NewConfig<(EmployeeOrder Order, Employee Employee, List<OrderDetailResult> Details), DetailedEmployeeOrderResult>()
            .Map(dest => dest, src => src.Order)
            .Map(dest => dest.EmployeeName, src => src.Employee.Name)
            .Map(dest => dest.Details, src => src.Details);

        config.NewConfig<(OrderDetail Detail, Product Product), OrderDetailResult>()
            .Map(dest => dest, src => src.Detail)
            .Map(dest => dest.ProductId, src => src.Detail.ProductId.Value)
            .Map(dest => dest.ProductName, src => src.Product.Name);
    }
}
