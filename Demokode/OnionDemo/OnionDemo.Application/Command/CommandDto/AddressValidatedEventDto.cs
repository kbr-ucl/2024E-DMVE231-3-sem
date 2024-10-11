namespace OnionDemo.Application.Command.CommandDto
{
    public record AddressValidatedEventDto(Guid DawaCorrelationId, Guid DawaId, AddressValidationStateDto ValidationState);
}
