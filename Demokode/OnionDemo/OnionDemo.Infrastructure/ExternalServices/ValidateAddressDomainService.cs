using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Values;

namespace OnionDemo.Infrastructure.ExternalServices;

public class ValidateAddressDomainService : IValidateAddressDomainService
{
    private readonly IAddressServiceProxy _addressService;

    public ValidateAddressDomainService(IAddressServiceProxy addressService)
    {
        _addressService = addressService;
    }
    AddressValidationResult IValidateAddressDomainService.ValidateAddress(string street, string city, string zipCode)
    {
        var result = _addressService.ValidateAddressAsync(street, city, zipCode).Result;
        return new AddressValidationResult(result.DawaId, Map(result.state));
    }

    private AddressValidationState Map(AddressValidationStateDto state)
    {
        switch (state)
        {
            case AddressValidationStateDto.Valid:
                return AddressValidationState.Valid;
            case AddressValidationStateDto.Pending:
                return AddressValidationState.Pending;
            case AddressValidationStateDto.Uncertain:
                return AddressValidationState.Uncertain;
            case AddressValidationStateDto.Invalid:
                return AddressValidationState.Invalid;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}