namespace AddressManager.Application.Command.CommandDto;

public record CreateAddressCommandDto(string Street, string Building, string ZipCode, string City);