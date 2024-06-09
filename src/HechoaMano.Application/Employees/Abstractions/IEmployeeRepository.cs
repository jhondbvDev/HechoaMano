using HechoaMano.Domain.Employees;

namespace HechoaMano.Application.Employees.Abstractions;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();
    Task CreateRangeAsync(List<Employee> employees);
    void UpdateRange(List<Employee> employees);
}
