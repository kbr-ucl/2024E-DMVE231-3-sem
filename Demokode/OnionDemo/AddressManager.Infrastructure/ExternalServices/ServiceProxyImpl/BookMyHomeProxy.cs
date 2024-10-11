using System.Net.Http.Json;
using AddressManager.Application;
using AddressManager.Domain.Entity;
using AddressManager.Domain.Values;
using Azure;
using Microsoft.Extensions.Logging;

namespace AddressManager.Infrastructure.ExternalServices.ServiceProxyImpl;

public class BookMyHomeProxy : IBookMyHomeProxy
{
    private readonly HttpClient _client;
    private readonly ILogger<BookMyHomeProxy> _logger;

    public BookMyHomeProxy(HttpClient client, ILogger<BookMyHomeProxy> logger)
    {
        _client = client;
        _logger = logger;
    }

    async Task IBookMyHomeProxy.SendValidatedAddressAsync(Address address)
    {
        var requestUri = "/AddressHandler";
        var requestDto = new AddressValidatedEventDto(address.DawaCorrelationId, address.DawaAddress.DawaId, MapValidationState(address.DawaAddress.ValidationState));
        var result = await _client.PostAsJsonAsync(requestUri, requestDto);
        if (!result.IsSuccessStatusCode)
        {
            var e = new Exception("Failed to send validated address to BookMyHome");
            _logger.LogError(e, "Failed to send validated address to BookMyHome");
        }
    }

    private AddressValidationStateDto MapValidationState(AddressValidationState validationState)
    {
        switch (validationState)
        {
            case AddressValidationState.Pending:
                return AddressValidationStateDto.Pending;
            case AddressValidationState.Valid:
                return AddressValidationStateDto.Valid;
            case AddressValidationState.Uncertain:
                return AddressValidationStateDto.Uncertain;
            case AddressValidationState.Invalid:
                return AddressValidationStateDto.Invalid;
            default:
                throw new ArgumentOutOfRangeException(nameof(validationState), validationState, null);
        }
    }
}

public record AddressValidatedEventDto(Guid DawaCorrelationId, Guid DawaId, AddressValidationStateDto ValidationState);
public enum AddressValidationStateDto
{
    Pending,
    Valid,
    Uncertain,
    Invalid
}

