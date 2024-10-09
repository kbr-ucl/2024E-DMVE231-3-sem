using AddressManager.Application.Query;
using AddressManager.Domain.Entity;
using AddressManager.Domain.Values;

namespace AddressManager.Infrastructure.Queries;

public class AddressQuery : IAddressQuery
{
    private readonly AddressContext _db;

    public AddressQuery(AddressContext db)
    {
        _db = db;
    }

    IEnumerable<Address> IAddressQuery.GetUnvalidatedAddresses()
    {
        return _db.Addresses.Where(a => a.DawaAddress.ValidationState == AddressValidationState.Pending).ToList();
    }
}