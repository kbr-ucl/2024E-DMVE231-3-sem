using OnionDemo.Domain.Values;

namespace OnionDemo.Infrastructure.ExternalServices;

public interface IAddressServiceProxy
{
    Task<AddressValidationResultDto> ValidateAddressAsync(string street, string city, string zipCode);
}

public record AddressValidationResultDto(string DawaId, AddressValidationStateDto state);
public record AddressValidationRequestDto(string StreetName, string Building, string ZipCode);

public enum AddressValidationStateDto
{
NotValidated,
Pending,
Valid,
Invalid
}
