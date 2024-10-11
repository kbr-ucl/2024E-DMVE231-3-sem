using AddressManager.Application.Command.CommandDto;
using AddressManager.Domain.Entity;

namespace AddressManager.Application.Command;

public interface IAddressCommand
{
    Address CreateAddress(CreateAddressCommandDto command);
    IEnumerable<Address> ValidateAddress(int id);
}