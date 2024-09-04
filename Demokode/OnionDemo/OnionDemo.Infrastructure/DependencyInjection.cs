using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application;
using OnionDemo.Application.Query;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Infrastructure.Queries;

namespace OnionDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBookingQuery, BookingQuery>();
        services.AddScoped<IBookingDomainService, BookingDomainService>();
        services.AddScoped<IBookingRepository, BookingRepository>();

        // Database
        // https://github.com/dotnet/SqlClient/issues/2239
        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
        // Add-Migration InitialMigration -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
        // Update-Database -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
        services.AddDbContext<BookMyHomeContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("BookMyHomeDbConnection"),
                x =>
                    x.MigrationsAssembly("OnionDemo.DatabaseMigration")));
        return services;
    }
}