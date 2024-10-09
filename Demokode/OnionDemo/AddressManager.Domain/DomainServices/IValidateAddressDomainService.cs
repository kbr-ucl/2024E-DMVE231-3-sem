using AddressManager.Domain.Values;

namespace AddressManager.Domain.DomainServices;

public interface IValidateAddressDomainService
{
    AddressValidationResult ValidateAddress(string street, string building, string zipCode);
}

public record AddressValidationResult(string DawaId, AddressValidationState ValidationState);