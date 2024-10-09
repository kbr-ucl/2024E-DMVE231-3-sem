using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Values;

namespace OnionDemo.Infrastructure.ExternalServices;

public class ValidateAddressDomainService : IValidateAddressDomainService
{
    AddressValidationResult IValidateAddressDomainService.ValidateAddress(string street, string city, string zipCode)
    {
        return new AddressValidationResult("1234", AddressValidationState.Valid);
    }
}