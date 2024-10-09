using AddressManager.Domain.Values;

namespace AddressManager.Domain.Entity;

public class Address : DomainEntity
{
    private Address()
    {
    }

    protected Address(string street, string building, string zipCode, string city, DawaAddress dawaAddress)
    {
        Street = street;
        Building = building;
        City = city;
        ZipCode = zipCode;
        DawaAddress = dawaAddress;
    }

    public string Street { get; protected set; } = null!;
    public string Building { get; protected set; } = null!;
    public string City { get; protected set; } = null!;
    public string ZipCode { get; protected set; } = null!;
    public DawaAddress DawaAddress { get; protected set; } = null!;

    public static Address Create(string street, string building, string zipCode, string city, IServiceProvider ioc)
    {
        var dawaAddress = DawaAddress.Create(street, building, zipCode, city, ioc);
        return new Address(street, building, zipCode, city, dawaAddress);
    }
}