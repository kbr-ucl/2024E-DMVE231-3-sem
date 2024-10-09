using AddressManager.Domain.Entity;

namespace AddressManager.Infrastructure.ExternalServices;

public interface IBookMyHomeProxy
{
    Task SendValidatedAddressAsync(Address address);
}