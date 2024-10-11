using AddressManager.Application.Command;
using AddressManager.Application.Query;
using Microsoft.Extensions.Logging;
using Quartz;

namespace AddressManager.Application.Jobs;

/// <summary>
///     https://www.quartz-scheduler.net/documentation/quartz-3.x/packages/aspnet-core-integration.html#using
/// </summary>
public class ValidatePendingAddressesJob : IJob
{
    private readonly IAddressCommand _command;
    private readonly IBookMyHomeProxy _serviceProxy;
    private readonly ILogger<ValidatePendingAddressesJob> _logger;
    private readonly IAddressQuery _query;

    public ValidatePendingAddressesJob(IAddressQuery query, IAddressCommand command, IBookMyHomeProxy serviceProxy, 
        ILogger<ValidatePendingAddressesJob> logger)
    {
        _query = query;
        _command = command;
        _serviceProxy = serviceProxy;
        _logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("ValidatePendingAddressesJob is running");
        var addressesToCheck = _query.GetUnvalidatedAddresses();
        foreach (var address in addressesToCheck)
        {
            _logger.LogInformation($"Validating address {address.Id}");
            _command.ValidateAddress(address.Id);
        }
        // Code that sends a periodic email to the user (for example)
        // Note: This method must always return a value 
        // This is especially important for trigger listeners watching job execution 
        return Task.CompletedTask;
    }
}