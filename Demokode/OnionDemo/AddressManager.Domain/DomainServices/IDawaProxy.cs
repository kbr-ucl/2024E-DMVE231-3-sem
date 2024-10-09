using System.Net;

namespace AddressManager.Domain.DomainServices;

public interface IDawaProxy
{
    Task<GetDawaAddressResponse> GetDawaAddressAsync(string streetName, string building, string zipCode, string city);
}

public record GetDawaAddressResponse(
    bool DawaResponded = true,
    HttpStatusCode StatusCode = HttpStatusCode.Accepted,
    string DawaReasonPhrase = "",
    bool AddressFound = false,
    Guid Id = default,
    string Kategori = "");
