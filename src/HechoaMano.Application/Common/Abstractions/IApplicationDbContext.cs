using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Employees;
using HechoaMano.Domain.Inventory.Aggregates;
using HechoaMano.Domain.Inventory.Entities;
using HechoaMano.Domain.Products;
using HechoaMano.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Application.Common.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Client> Clients { get; set; }
    DbSet<Employee> Employees { get; set; }
    DbSet<ClientOrder> ClientOrders { get; set; }
    DbSet<OrderDetail> ClientOrderDetails { get; set; }
    DbSet<EmployeeOrder> EmployeeOrders { get; set; }
    DbSet<OrderDetail> EmployeeOrderDetails { get; set; }
    DbSet<InventoryControl> InventoryControls { get; set; }
    DbSet<InventoryControlDetail> InventoryControlDetails { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Family> Families { get; set; }
    DbSet<FamilyType> FamilyTypes { get; set; }
    DbSet<ProductStock> ProductStocks { get; set; }
    DbSet<Region> Regions { get; set; }
    DbSet<Size> Sizes { get; set; }
    DbSet<SubFamily> SubFamilies { get; set; }
    Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
}
