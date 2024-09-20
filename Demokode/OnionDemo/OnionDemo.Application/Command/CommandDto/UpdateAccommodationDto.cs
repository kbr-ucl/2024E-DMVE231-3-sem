namespace OnionDemo.Application.Command.CommandDto;

public record UpdateAccommodationDto
{
    public int HostId { get; init; }
    public int AccommodationId { get; init; }
}