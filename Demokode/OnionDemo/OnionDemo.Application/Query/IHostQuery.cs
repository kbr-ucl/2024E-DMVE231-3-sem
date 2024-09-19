using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Application.Query;

public interface IHostQuery
{
    HostDto? GetAccommodations(int hostId);
}