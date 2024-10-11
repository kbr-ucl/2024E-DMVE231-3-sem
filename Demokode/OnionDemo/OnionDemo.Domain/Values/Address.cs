using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Domain.Values;

public record Address : ValueBase
{
    protected Address()
    {
    }

    private Address(string street, string building, string city, string zipCode, AddressValidationResult dawaValidationRespose)
    {
        Street = street;
        Building = building;
        City = city;
        ZipCode = zipCode;
        ValidationState = dawaValidationRespose.ValidationState;
        DawaId = dawaValidationRespose.DawaId;
        DawaCorrelationId = dawaValidationRespose.DawaCorrelationId;
    }

    public string Street { get; private set; }
    public string Building { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public bool IsValid => ValidationState == AddressValidationState.Valid || ValidationState == AddressValidationState.Pending;
    public Guid DawaId { get; protected set; }
    public Guid DawaCorrelationId { get; protected set; }
    public AddressValidationState ValidationState { get; protected set; }

    public static Address Create(string street, string building, string zipCode, string city, IServiceProvider serviceProvider)
    {
        var dawaService = serviceProvider.GetRequiredService<IValidateAddressDomainService>();
        var dawaValidationRespose = dawaService.ValidateAddress(street, building, zipCode, city);
        return new Address(street, building, city, zipCode, dawaValidationRespose);
    }

    public void UpdateValidationState(AddressValidationState validationState)
    {
       ValidationState = validationState;
    }
}

public enum AddressValidationState
{
    Pending,
    Valid,
    Uncertain,
    Invalid
}