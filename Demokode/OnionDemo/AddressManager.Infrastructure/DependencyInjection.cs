using System.Diagnostics;
using AddressManager.Application.Command;
using AddressManager.Domain.DomainServices;
using AddressManager.Infrastructure.ExternalServices.ServiceProxyImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddressManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAddressRepository, AddressRepository>();

        // External services
        services.AddHttpClient<IDawaProxy, DawaProxy>(client =>
        {
            var uri = configuration.GetSection("ExternalServices:Dawa:Uri").Value;
            Debug.Assert(string.Empty != null, "String.Empty != null");
            client.BaseAddress = new Uri(uri ?? string.Empty);
        });


        // Database
        // https://github.com/dotnet/SqlClient/issues/2239
        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
        // Add-Migration InitialMigration -Context AddressContext -Project AddressManager.DatabaseMigration
        // Update-Database -Context AddressContext -Project AddressManager.DatabaseMigration
        services.AddDbContext<AddressContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("AddressDbConnection"),
                x =>
                    x.MigrationsAssembly("AddressManager.DatabaseMigration")));


        return services;
    }
}