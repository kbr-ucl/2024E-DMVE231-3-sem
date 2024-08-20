using Microsoft.Extensions.Logging;

namespace DependencyInjectionInConsole;

public class FooService : IFoo
{
    private readonly IBar _bar;
    private readonly ILogger _logger;

    public FooService(ILogger<FooService> logger, IBar bar)
    {
        _logger = logger;
        _bar = bar;
    }

    public void GetData()
    {
        _logger.LogInformation(_bar.GetData());
    }
}