using System.Text.Json.Nodes;
using AddressManager.Domain.DomainServices;

namespace AddressManager.Infrastructure.ExternalServices.ServiceProxyImpl;

public class DawaProxy : IDawaProxy
{
    private readonly HttpClient _client;

    public DawaProxy(HttpClient client)
    {
        _client = client;
    }
    async Task<GetDawaAddressResponse> IDawaProxy.GetDawaAddressAsync(string streetName, string building, string zipCode, string city)
    {
        var requestUri = $"/datavask/adresser?betegnelse={streetName} {building}, {zipCode} {city}";
        var dawaResponse = await _client.GetAsync(requestUri);

        if (!dawaResponse.IsSuccessStatusCode)
        {
            return new GetDawaAddressResponse(false, dawaResponse.StatusCode, dawaResponse.ReasonPhrase ?? "");
        }

        var jsonResponse = await dawaResponse.Content.ReadAsStringAsync();
        JsonNode dawaNode = JsonNode.Parse(jsonResponse)!;
        var kategoriNode = dawaNode["kategori"];
        var resultaterNode = dawaNode["resultater"];
        var adresseNode = resultaterNode![0]!["adresse"];
        var dawaIdNode = adresseNode!["id"];


        if (kategoriNode != null
            && Guid.TryParse(dawaIdNode?.ToString() ?? string.Empty, out Guid dataId))
        {
            return new GetDawaAddressResponse(AddressFound:true, Id:dataId, Kategori:kategoriNode.ToString());
        };

        return new GetDawaAddressResponse(false);
    }
}