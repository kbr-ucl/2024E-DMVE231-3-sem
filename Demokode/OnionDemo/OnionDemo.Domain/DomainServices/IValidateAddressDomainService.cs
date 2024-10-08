namespace OnionDemo.Domain.DomainServices;

public interface IValidateAddressDomainService
{
    AddressValidationResult ValidateAddress(string street, string city, string zipCode);
}

public record AddressValidationResult(bool IsValid, string DawaId);