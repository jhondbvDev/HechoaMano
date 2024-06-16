using FluentValidation;
using HechoaMano.Application.Common.Behaviors;
using HechoaMano.Application.Products.Events;
using HechoaMano.Domain.Inventory.Events;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HechoaMano.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => { 
            config.RegisterServicesFromAssemblies(ApplicationAssemblyReference.Assembly);
        });

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

        services.AddMappings();

        return services;
    }

    private static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(ApplicationAssemblyReference.Assembly);

        services.AddSingleton(mappingConfig);

        return services;
    }
}
