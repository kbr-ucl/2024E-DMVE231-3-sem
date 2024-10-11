using AddressManager.Domain.Entity;

namespace AddressManager.Application.Command;

public interface IAddressRepository
{
    Address? GetAddress(string street, string building, string zipCode, string city);
    void Add(Address? address);
    Address GetAddress(int id);
    void Update();
}