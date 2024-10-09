namespace OnionDemo.Application.Command.CommandDto
{
    public record AddressValidatedEventDto(Guid DawaId, AddressValidationStateDto ValidationState);
}
