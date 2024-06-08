using HechoaMano.Domain.Employees;
using Mapster;

namespace HechoaMano.Application.Employees.Common.Mappings;

public class EmployeeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Employee, EmployeeResult>()
            .Map(dest => dest.Id, source => source.Id.Value);
    }
}
