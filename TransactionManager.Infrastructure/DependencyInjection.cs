using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionManager.Application.Common.Interfaces;
using TransactionManager.Infrastructure.Files;
using TransactionManager.Infrastructure.Persistence;
using TransactionManager.Infrastructure.Persistence.Configurations.Converters;

namespace TransactionManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TransactionManagerDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TransactionManagerDB"),
                    b => b.MigrationsAssembly(typeof(TransactionManagerDbContext).Assembly.FullName)));

            services.AddScoped<ITransactionManagerDbContext>(provider => provider.GetService<TransactionManagerDbContext>());
            services.AddTransient<IValueConverterFactory, ValueConverterFactory>();

            services.AddTransient<ICsvParser, CsvParser>();
            services.AddTransient<ICsvBuilder, CsvBuilder>();

            return services;
        }
    }
}
