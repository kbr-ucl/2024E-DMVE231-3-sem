using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Domain.Values;

public record Address : ValueBase
{
    protected Address()
    {
    }

    private Address(string street, string city, string zipCode, AddressValidationResult dawaValidationRespose)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        IsValid = dawaValidationRespose.IsValid;
        DawaId = dawaValidationRespose.DawaId;
    }

    public string Street { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public bool IsValid { get; protected set; }
    public string DawaId { get; protected set; }

    public static Address Create(string street, string city, string zipCode, IServiceProvider serviceProvider)
    {
        var dawaService = serviceProvider.GetRequiredService<IValidateAddressDomainService>();
        var dawaValidationRespose = dawaService.ValidateAddress(street, city, zipCode);
        return new Address(street, city, zipCode, dawaValidationRespose);
    }
}