using HechoaMano.Domain.Common.ValueObjects;
using HechoaMano.Domain.Employees;

namespace HechoaMano.Application.Employees.Abstractions;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetAsync(UserId id);
    Task CreateRangeAsync(List<Employee> employees);
    void UpdateRange(List<Employee> employees);
}
