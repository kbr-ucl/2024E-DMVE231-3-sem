namespace OnionDemo.Infrastructure.ExternalServices;

public interface IAddressServiceProxy
{
    Task<AddressValidationResultDto> ValidateAddress(string street, string city, string zipCode);
}

public record AddressValidationResultDto(bool IsValid, string DawaId);
public record AddressValidationRequestDto(string StreetName, string Building, string ZipCode);