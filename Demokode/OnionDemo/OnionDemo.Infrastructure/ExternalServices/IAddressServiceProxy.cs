using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Infrastructure.ExternalServices;

public interface IAddressServiceProxy
{
    Task<AddressValidationResultDto> ValidateAddressAsync(string street, string building, string zipCode, string city);
}

public record AddressValidationResultDto(Guid DawaId, AddressValidationStateDto ValidationState);

public record AddressValidationRequestDto(string StreetName, string Building, string ZipCode, string City);