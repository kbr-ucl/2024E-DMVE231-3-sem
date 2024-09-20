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

    HostDto? IHostQuery.GetAccommodations(int hostId)
    {
        var host = _db.Hosts
            .Include(a => a.Accommodations)
            .ThenInclude(b => b.Bookings)
            .FirstOrDefault(h => h.Id == hostId);

        if (host == null) return null;

        return new HostDto
        {
            Id = host.Id,
            Accommodations = host.Accommodations.Select(a => new AccommodationDto
            {
                Id = a.Id,
                HostId = a.Host.Id,
                Bookings = a.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    RowVersion = b.RowVersion
                })
            })
        };
    }
}