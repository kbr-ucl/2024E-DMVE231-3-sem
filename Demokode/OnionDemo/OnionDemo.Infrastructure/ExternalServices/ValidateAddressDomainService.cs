using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Infrastructure.ExternalServices;

public class ValidateAddressDomainService : IValidateAddressDomainService
{
    DawaValidationRespose IValidateAddressDomainService.ValidateAddress(string street, string city, string zipCode)
    {
        return new DawaValidationRespose(true, "1234");
    }
}