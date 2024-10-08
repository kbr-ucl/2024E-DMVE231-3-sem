using System.Net.Http.Json;

namespace OnionDemo.Infrastructure.ExternalServices.ServiceProxy;

public class AddressServiceProxy : IAddressServiceProxy
{
    private readonly HttpClient _client;

    public AddressServiceProxy(HttpClient client)
    {
        _client = client;
    }

    async Task<AddressValidationResultDto> IAddressServiceProxy.ValidateAddress(string street, string city,
        string zipCode)
    {
        var requestDto = new AddressValidationRequestDto(street, city, zipCode);
        var response = await _client.PostAsJsonAsync("/Address", requestDto);
        if (!response.IsSuccessStatusCode) return new AddressValidationResultDto(false, string.Empty);
        var result = await response.Content.ReadFromJsonAsync<AddressValidationResultDto>();
        return result ?? new AddressValidationResultDto(false, string.Empty);
    }


    //public async Task<DawaValidationRespose> ValidateAddress(string street, string city, string zipCode)
    //{
    //    var response = await _client.GetAsync($"https://dawa.aws.dk/adresser?vejnavn={street}&postnr={zipCode}&bynavn={city}");
    //    if (response.IsSuccessStatusCode)
    //    {
    //        var content = await response.Content.ReadAsStringAsync();
    //        var address = JsonSerializer.Deserialize<DawaAddress>(content);
    //        return new DawaValidationRespose(true, address.DawaId);
    //    }
    //    return new DawaValidationRespose(false, string.Empty);
    //}
}