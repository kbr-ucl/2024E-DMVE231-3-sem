using AddressManager.Domain.Entity;

namespace AddressManager.Application.Query;

public interface IAddressQuery
{
    IEnumerable<Address> GetUnvalidatedAddresses();
}