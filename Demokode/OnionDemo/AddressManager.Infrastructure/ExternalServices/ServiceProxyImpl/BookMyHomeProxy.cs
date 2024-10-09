using System.Net.Http.Json;
using AddressManager.Domain.Entity;
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
        var requestDto = new AddressValidatedEventDto();
        var result = await _client.PostAsJsonAsync(requestUri, requestDto);
        if (!result.IsSuccessStatusCode)
        {
            var e = new Exception("Failed to send validated address to BookMyHome");
            _logger.LogError(e, "Failed to send validated address to BookMyHome");
        }
    }
}

public record AddressValidatedEventDto;