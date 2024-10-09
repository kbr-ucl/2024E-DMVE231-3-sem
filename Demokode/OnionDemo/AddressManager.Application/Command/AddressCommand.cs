using AddressManager.Application.Command.CommandDto;
using AddressManager.Domain.Entity;
using AddressManager.Domain.Values;

namespace AddressManager.Application.Command;

public class AddressCommand : IAddressCommand
{
    private readonly IAddressRepository _repository;
    private readonly IServiceProvider _ioc;

    public AddressCommand(IAddressRepository repository, IServiceProvider ioc)
    {
        _repository = repository;
        _ioc = ioc;
    }

    Address IAddressCommand.CreateAddress(CreateAddressCommandDto command)
    {
        var address = _repository.GetAddress(command.Street, command.Building, command.ZipCode, command.City);

        // Hvis adressen er kendt i forvejen, returneres den
        if (address != null)
        {
            return address;
        }

        // Hvis adressen ikke er kendt, oprettes den
        address = Address.Create(command.Street, command.Building, command.ZipCode, command.City, _ioc);
        _repository.Add(address);
        return address;
    }

    void IAddressCommand.ValidateAddress(int id)
    {
        var address = _repository.GetAddress(id);
        address.Validate(_ioc);
        _repository.Add(address);
        if (address.DawaAddress.ValidationState != AddressValidationState.Pending)
        {
            
        }
    }
}