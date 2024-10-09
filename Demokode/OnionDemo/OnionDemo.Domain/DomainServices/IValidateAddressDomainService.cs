using OnionDemo.Domain.Values;

namespace OnionDemo.Domain.DomainServices;

public interface IValidateAddressDomainService
{
    AddressValidationResult ValidateAddress(string street, string building, string zipCode);
}

public record AddressValidationResult(string DawaId, AddressValidationState ValidationState);