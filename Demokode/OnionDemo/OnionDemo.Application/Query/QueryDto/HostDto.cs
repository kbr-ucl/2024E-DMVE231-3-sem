// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace OnionDemo.Application.Query.QueryDto;

public class HostDto
{
    public int Id { get; set; }
    public required IEnumerable<AccommodationDto> Accommodations { get; set; }
}