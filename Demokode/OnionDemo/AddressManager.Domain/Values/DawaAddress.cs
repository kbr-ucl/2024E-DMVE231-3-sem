using AddressManager.Domain.DomainServices;
using Microsoft.Extensions.DependencyInjection;

namespace AddressManager.Domain.Values;

public record DawaAddress : ValueBase
{


    private DawaAddress()
    {
    }

    protected DawaAddress(GetDawaAddressResponse dawaResponse)
    {
        if (!dawaResponse.DawaResponded)
        {
            ValidationState = AddressValidationState.Pending;
            DawaHttpError = dawaResponse.StatusCode.ToString();
            DawaErrorReasonPhrase = dawaResponse.DawaReasonPhrase;
            return;
        }

        if (!dawaResponse.AddressFound)
        {
            ValidationState = AddressValidationState.Invalid;
            return;
        }

        DawaId = dawaResponse.Id;
        Kategori = dawaResponse.Kategori;
        if (Kategori != "A")
        {
            ValidationState = AddressValidationState.Uncertain;
            return;
        }

        ValidationState = AddressValidationState.Valid;
    }

    public string Kategori { get; protected set; } = string.Empty;
    public string DawaHttpError { get; protected set; } = string.Empty;
    public string DawaErrorReasonPhrase { get; protected set; } = string.Empty;

    public bool IsValid => ValidationState == AddressValidationState.Valid || ValidationState == AddressValidationState.Pending;
    public Guid DawaId { get; protected set; } = Guid.Empty;
    public AddressValidationState ValidationState { get; protected set; }

    public static DawaAddress Create(string street, string building, string zipCode, string city, IServiceProvider ioc)
    {
        var dawaService = ioc.GetRequiredService<IDawaProxy>();
        var dawaValidationRespose = dawaService.GetDawaAddressAsync(street, building, zipCode, city).Result;
        return new DawaAddress(dawaValidationRespose);
    }
}