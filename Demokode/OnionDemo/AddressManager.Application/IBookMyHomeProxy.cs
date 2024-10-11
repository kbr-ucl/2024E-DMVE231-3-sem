using AddressManager.Domain.Entity;

namespace AddressManager.Application;

public interface IBookMyHomeProxy
{
    Task SendValidatedAddressAsync(Address address);
}