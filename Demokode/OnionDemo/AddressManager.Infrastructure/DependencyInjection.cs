using System.Diagnostics;
using AddressManager.Domain.DomainServices;
using AddressManager.Infrastructure.ExternalServices;
using AddressManager.Infrastructure.ExternalServices.ServiceProxyImpl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddressManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // External services
        services.AddHttpClient<IDawaProxy, DawaProxy>(client =>
        {
            var uri = configuration.GetSection("ExternalServices:Dawa:Uri").Value;
            Debug.Assert(String.Empty != null, "String.Empty != null");
            client.BaseAddress = new Uri(uri ?? string.Empty);
        });


        //// Database
        //// https://github.com/dotnet/SqlClient/issues/2239
        //// https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
        //// Add-Migration InitialMigration -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
        //// Update-Database -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
        //services.AddDbContext<BookMyHomeContext>(options =>
        //    options.UseSqlServer(
        //        configuration.GetConnectionString
        //            ("BookMyHomeDbConnection"),
        //        x =>
        //            x.MigrationsAssembly("OnionDemo.DatabaseMigration")));


        return services;
    }
}