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
        address = Address.Create(command.DawaCorrelationId, command.Street, command.Building, command.ZipCode, command.City, _ioc);
        _repository.Add(address);
        return address;
    }

    IEnumerable<Address> IAddressCommand.ValidateAddress(int id)
    {
        List<Address> validatedAddresses = new List<Address>();
        var address = _repository.GetAddress(id);
        address.Validate(_ioc);
        _repository.Update();
        if (address.DawaAddress.ValidationState != AddressValidationState.Pending)
        {
            validatedAddresses.Add(address);
        }

        return validatedAddresses;
    }
}