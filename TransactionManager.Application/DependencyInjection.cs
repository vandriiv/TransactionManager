using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TransactionManager.Application.Common.Behaviours;
using TransactionManager.Application.Common.Mappers;

namespace TransactionManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {          
            services.AddMediatR(Assembly.GetExecutingAssembly());            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddTransient<EnumMapper>();

            return services;
        }
    }
}
