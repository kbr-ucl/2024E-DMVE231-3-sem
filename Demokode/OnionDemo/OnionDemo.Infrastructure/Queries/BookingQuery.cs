using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Query;
using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Infrastructure.Queries;

public class BookingQuery : IBookingQuery
{
    private readonly BookMyHomeContext _db;

    public BookingQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    BookingDto IBookingQuery.GetBooking(int accommodationId, int bookingId)
    {
        var accomodation = _db.Accommodations.Include(b => b.Bookings).AsNoTracking().Single(a => a.Id == accommodationId);
        var booking = accomodation.Bookings.Single(b => b.Id == bookingId);

        return new BookingDto
        {
            Id = booking.Id,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            AccommodationId = accomodation.Id,
            RowVersion = booking.RowVersion
        };
    }


    IEnumerable<BookingDto> IBookingQuery.GetBookings(int accommodationId)
    {
        var accomodation = _db.Accommodations.Include(b => b.Bookings).AsNoTracking().Single(a => a.Id == accommodationId);
        var result = _db.Bookings.AsNoTracking().Select(a => new BookingDto
        {
            Id = a.Id,
            StartDate = a.StartDate,
            EndDate = a.EndDate,
            AccommodationId = accomodation.Id,
            RowVersion = a.RowVersion
        });
        return result;
    }
}