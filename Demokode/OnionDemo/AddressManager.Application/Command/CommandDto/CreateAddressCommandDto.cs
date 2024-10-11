
namespace AddressManager.Application.Command.CommandDto;

public record CreateAddressCommandDto(
    Guid DawaCorrelationId,
    string Street,
    string Building,
    string ZipCode,
    string City);

