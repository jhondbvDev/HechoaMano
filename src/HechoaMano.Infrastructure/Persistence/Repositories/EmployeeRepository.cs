using HechoaMano.Application.Employees.Abstractions;
using HechoaMano.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace HechoaMano.Infrastructure.Persistence.Repositories;

public class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<List<Employee>> GetAllAsync() => await _context.Employees.AsNoTracking().ToListAsync();
    public async Task CreateRangeAsync(List<Employee> employees) => await _context.Employees.AddRangeAsync(employees);
    public void UpdateRange(List<Employee> employees) => _context.UpdateRange(employees);
}
