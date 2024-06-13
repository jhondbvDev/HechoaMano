using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Employees;
using HechoaMano.Domain.Products;
using Microsoft.AspNetCore.Http;

namespace HechoaMano.Application.Common.Abstractions;

public interface IFileDataExtractionService
{
    bool ExtractClientsFromFile(IFormFile file, out List<Client> clients);
    bool ExtractEmployeesFromFile(IFormFile file, out List<Employee> employees);
    bool ExtractProductsFromFile(IFormFile file, out List<Product> products);
}
