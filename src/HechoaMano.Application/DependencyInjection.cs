using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechoaMano.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => { 
                config.RegisterServicesFromAssemblies(ApplicationAssemblyReference.Assembly);
            });
            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();
            return services;
        }
    }
}
