namespace OnionDemo.Domain.DomainServices;

public interface IValidateAddressDomainService
{
    DawaValidationRespose ValidateAddress(string street, string city, string zipCode);
}

public record DawaValidationRespose(bool IsValid, string DawaId);