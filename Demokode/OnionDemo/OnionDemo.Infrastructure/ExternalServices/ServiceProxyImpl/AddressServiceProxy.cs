using System.Net.Http.Json;
using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Infrastructure.ExternalServices.ServiceProxyImpl;

public class AddressServiceProxy : IAddressServiceProxy
{
    private readonly HttpClient _client;

    public AddressServiceProxy(HttpClient client)
    {
        _client = client;
    }

    async Task<AddressValidationResultDto> IAddressServiceProxy.ValidateAddressAsync(Guid dawaCorrelationId,
        string street, string building,
        string zipCode, string city)
    {
        var requestDto = new AddressValidationRequestDto(dawaCorrelationId, street, building, zipCode, city);
        var response = await _client.PostAsJsonAsync("/Address", requestDto);
        if (!response.IsSuccessStatusCode) return new AddressValidationResultDto(dawaCorrelationId, Guid.Empty, AddressValidationStateDto.Uncertain);
        var result = await response.Content.ReadFromJsonAsync<AddressValidationResultDto>();
        return result ?? new AddressValidationResultDto(dawaCorrelationId, Guid.Empty, AddressValidationStateDto.Uncertain);
    }
}