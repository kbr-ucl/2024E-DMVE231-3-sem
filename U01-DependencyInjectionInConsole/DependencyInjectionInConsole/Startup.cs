using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionInConsole;

public class Startup
{
    public static ServiceProvider Configure()
    {
        var provider = new ServiceCollection()
            .AddSingleton<IFoo, FooService>()
            .AddSingleton<IBar, BarService>()
            .AddLogging(fs => fs.AddConsole())
            .BuildServiceProvider(validateScopes: true);
        return provider;
    }
}