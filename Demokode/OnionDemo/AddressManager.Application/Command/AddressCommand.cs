using AddressManager.Application.Command.CommandDto;
using AddressManager.Domain.Entity;

namespace AddressManager.Application.Command;

public class AddressCommand : IAddressCommand
{
    private readonly IServiceProvider _ioc;

    public AddressCommand(IServiceProvider ioc)
    {
        _ioc = ioc;
    }

    Address IAddressCommand.CreateAddress(CreateAddressCommandDto command)
    {
        var address = Address.Create(command.Street, command.Building, command.ZipCode, command.City, _ioc);
        return address;
    }
}