using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Infrastructure.ExternalServices;

public class ValidateAddressDomainService : IValidateAddressDomainService
{
    AddressValidationResult IValidateAddressDomainService.ValidateAddress(string street, string city, string zipCode)
    {
        return new AddressValidationResult(true, "1234");
    }
}