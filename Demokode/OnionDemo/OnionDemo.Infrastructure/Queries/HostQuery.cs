using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Query;
using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Infrastructure.Queries;

public class HostQuery : IHostQuery
{
    private readonly BookMyHomeContext _db;

    public HostQuery(BookMyHomeContext db)
    {
        _db = db;
    }
    IEnumerable<AccommodationDto> IHostQuery.GetAccommodations(int hostId)
    {
        //var host = _db.Hosts
        //.Include(a => a.Accommodations)
        //.ThenInclude(b => b.Bookings)
        //.FirstOrDefault(h => h.Id == hostId);
        return new List<AccommodationDto>();
    }
}