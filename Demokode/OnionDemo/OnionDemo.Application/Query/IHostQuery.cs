using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Application.Query;

public interface IHostQuery
{
    IEnumerable<AccommodationDto> GetAccommodations(int hostId);
}