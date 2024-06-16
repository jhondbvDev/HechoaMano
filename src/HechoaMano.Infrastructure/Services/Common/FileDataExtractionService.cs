using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Domain.Clients;
using HechoaMano.Domain.Clients.ValueObjects;
using HechoaMano.Domain.Employees;
using HechoaMano.Domain.Products;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

#pragma warning disable IDE0063 // Use simple 'using' statement

namespace HechoaMano.Infrastructure.Services.Common
{
    public sealed class FileDataExtractionService : IFileDataExtractionService
    {
        private readonly string[] clientFileHeaders = ["Documento", "Nombre", "Direccion", "Telefono", "Ciudad", "Nombre Tienda", "Descuento"];
        private readonly string[] employeeFileHeaders = ["Documento", "Nombre"];
        private readonly string[] productFileHeaders = ["Id","Nombre", "Familia", "SubFamilia", "Tipo", "Tamano", "Region", "Costo", "Precio Venta"];

        public bool ExtractClientsFromFile(IFormFile file, out List<Client> clients)
        {
            clients = [];

            using var excelToProcess = file.OpenReadStream();

            using (var package = new ExcelPackage(excelToProcess))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                if (!ValidateFile(package, clientFileHeaders))
                {
                    return false;
                }

                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    var name = worksheet.Cells[i, 2].Value.ToString()!;
                    var documentId = worksheet.Cells[i, 1].Value.ToString()!;
                    var address = worksheet.Cells[i, 3].Value.ToString()!;
                    var phoneNumber = worksheet.Cells[i, 4].Value.ToString()!;
                    var city = worksheet.Cells[i, 5].Value.ToString()!;
                    var shopName = worksheet.Cells[i, 6].Value.ToString()!;
                    var discount = Convert.ToDecimal(worksheet.Cells[i, 7].Value.ToString());

                    clients.Add(Client.Create(
                        name, 
                        documentId, 
                        ContactInformation.Create(address, phoneNumber, city),
                        shopName,
                        discount)
                    );
                }
            }

            return true;
        }

        public bool ExtractEmployeesFromFile(IFormFile file, out List<Employee> employees)
        {
            employees = [];

            using var excelToProcess = file.OpenReadStream();

            using (var package = new ExcelPackage(excelToProcess))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                if (!ValidateFile(package, employeeFileHeaders))
                {
                    return false;
                }

                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    var name = worksheet.Cells[i, 2].Value.ToString()!;
                    var documentId = worksheet.Cells[i, 1].Value.ToString()!;

                    employees.Add(Employee.Create(
                        name,
                        documentId)
                    );
                }
            }

            return true;
        }

        public bool ExtractProductsFromFile(IFormFile file, out List<Product> products)
        {
            products = [];

            using var excelToProcess = file.OpenReadStream();

            using (var package = new ExcelPackage(excelToProcess))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                if (!ValidateFile(package, productFileHeaders))
                {
                    return false;
                }

                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    var id = Guid.Parse(worksheet.Cells[i, 1].Value.ToString()!);
                    var name = worksheet.Cells[i, 2].Value.ToString()!;
                    var familyTypeId = worksheet.Cells[i, 5].Value?.ToString();
                    var familyId = Guid.Parse(worksheet.Cells[i, 3].Value.ToString()!);
                    var subFamilyId = worksheet.Cells[i, 4].Value?.ToString();
                    var sizeId = worksheet.Cells[i, 6].Value?.ToString();
                    var regionId = Guid.Parse(worksheet.Cells[i, 7].Value.ToString()!);
                    var sellPrice = Convert.ToDecimal(worksheet.Cells[i, 9].Value.ToString());
                    var buyPrice = Convert.ToDecimal(worksheet.Cells[i, 8].Value.ToString());

                    products.Add(Product.Create(
                        id,
                        name,
                        !string.IsNullOrWhiteSpace(familyTypeId) ? Guid.Parse(familyTypeId) : null,
                        familyId,
                        !string.IsNullOrWhiteSpace(subFamilyId) ? Guid.Parse(subFamilyId) : null,
                        !string.IsNullOrWhiteSpace(sizeId) ? Guid.Parse(sizeId) : null,
                        regionId,
                        sellPrice,
                        buyPrice)
                    );
                }
            }

            return true;
        }

        #region Private Methods
        private static bool ValidateFile(ExcelPackage file, string[] headers)
        {
            ExcelWorksheet worksheet = file.Workbook.Worksheets[0];
            for (int i = 1; i < headers.Length + 1; i++)
            {
                if (!(worksheet.Cells[1, i].Value.ToString()?.Trim() == headers[i - 1]))
                {
                    return false;
                }
            }

            return worksheet.Dimension.End.Row > 1;
        }
        #endregion
    }
}

#pragma warning restore IDE0063 // Use simple 'using' statement