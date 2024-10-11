using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Infrastructure.ExternalServices;

public interface IAddressServiceProxy
{
    Task<AddressValidationResultDto> ValidateAddressAsync(Guid dawaCorrelationId, string street, string building,
        string zipCode, string city);
}

public record AddressValidationResultDto(Guid DawaCorrelationId, Guid DawaId, AddressValidationStateDto ValidationState);

public record AddressValidationRequestDto(Guid DawaCorrelationId, string StreetName, string Building, string ZipCode, string City);