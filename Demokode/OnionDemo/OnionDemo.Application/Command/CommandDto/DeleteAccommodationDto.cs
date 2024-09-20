namespace OnionDemo.Application.Command.CommandDto;

public record DeleteAccommodationDto
{
    public int HostId { get; init; }
    public int AccommodationId { get; init; }
}