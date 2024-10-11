﻿using OnionDemo.Domain.Values;

namespace OnionDemo.Domain.DomainServices;

public interface IValidateAddressDomainService
{
    AddressValidationResult ValidateAddress(string street, string building, string zipCode, string city);
}

public record AddressValidationResult(Guid DawaId, AddressValidationState ValidationState);