using AddressManager.Domain.Values;

namespace AddressManager.Domain.Entity;

public class Address : DomainEntity
{
    private Address()
    {
    }

    protected Address(Guid dawaCorrelationId, string street, string building, string zipCode, string city, DawaAddress dawaAddress,
        AddressHashCode addressHashCode)
    {
        Street = street;
        Building = building;
        City = city;
        ZipCode = zipCode;
        DawaAddress = dawaAddress;
        AddressHashCode = addressHashCode;
        DawaCorrelationId = dawaCorrelationId;
    }

    public string Street { get; protected set; } = null!;
    public string Building { get; protected set; } = null!;
    public string City { get; protected set; } = null!;
    public string ZipCode { get; protected set; } = null!;
    public DawaAddress DawaAddress { get; protected set; } = null!;
    public AddressHashCode AddressHashCode { get; protected set; }
    public Guid DawaCorrelationId { get; protected set; }

    public static Address Create(Guid dawaCorrelationId, string street, string building, string zipCode, string city, IServiceProvider ioc)
    {
        var dawaAddress = DawaAddress.Create(street, building, zipCode, city, ioc);
        var addressHashCode = AddressHashCode.Create(street, building, zipCode, city);
        return new Address(dawaCorrelationId, street, building, zipCode, city, dawaAddress, addressHashCode);
    }

    public void Validate(IServiceProvider ioc)
    {
        var dawaAddress = DawaAddress.Create(Street, Building, ZipCode, City, ioc);
        DawaAddress = dawaAddress;
    }
}