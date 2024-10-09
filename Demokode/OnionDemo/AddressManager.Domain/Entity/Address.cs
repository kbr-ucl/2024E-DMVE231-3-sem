using AddressManager.Domain.Values;

namespace AddressManager.Domain.Entity;

public class Address : DomainEntity
{
    private Address()
    {
    }

    protected Address(string street, string building, string zipCode, string city, DawaAddress dawaAddress, AddressHashCode addressHashCode)
    {
        Street = street;
        Building = building;
        City = city;
        ZipCode = zipCode;
        DawaAddress = dawaAddress;
        AddressHashCode = addressHashCode;
    }

    public string Street { get; protected set; } = null!;
    public string Building { get; protected set; } = null!;
    public string City { get; protected set; } = null!;
    public string ZipCode { get; protected set; } = null!;
    public DawaAddress DawaAddress { get; protected set; } = null!;
    public AddressHashCode AddressHashCode { get; protected set; }

    public static Address Create(string street, string building, string zipCode, string city, IServiceProvider ioc)
    {
        var dawaAddress = DawaAddress.Create(street, building, zipCode, city, ioc);
        var addressHashCode = AddressHashCode.Create(street, building, zipCode, city);
        return new Address(street, building, zipCode, city, dawaAddress, addressHashCode);
    }
}