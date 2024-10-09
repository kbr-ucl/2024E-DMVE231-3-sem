using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Query;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Infrastructure.ExternalServices;
using OnionDemo.Infrastructure.ExternalServices.ServiceProxyImpl;
using OnionDemo.Infrastructure.Queries;

namespace OnionDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHostQuery, HostQuery>();
        services.AddScoped<IBookingQuery, BookingQuery>();
        services.AddScoped<IAccommodationRepository, AccommodationRepository>();
        services.AddScoped<IHostRepository, HostRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork<BookMyHomeContext>>();
        services.AddScoped<IValidateAddressDomainService, ValidateAddressDomainService>();

        // External services
        services.AddHttpClient<IAddressServiceProxy, AddressServiceProxy>(client =>
        {
            var uri = configuration.GetSection("ExternalServices:AddressService:Uri").Value;
            Debug.Assert(String.Empty != null, "String.Empty != null");
            client.BaseAddress = new Uri(uri ?? string.Empty);
        });


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