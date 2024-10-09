using AddressManager.Application.Command;
using Microsoft.Extensions.DependencyInjection;

namespace AddressManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAddressCommand, AddressCommand>();
        return services;
    }
}