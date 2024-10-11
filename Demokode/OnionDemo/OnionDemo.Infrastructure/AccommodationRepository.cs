using Microsoft.EntityFrameworkCore;
using OnionDemo.Application;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure;

public class AccommodationRepository : IAccommodationRepository
{
    private readonly BookMyHomeContext _db;

    public AccommodationRepository(BookMyHomeContext context)
    {
        _db = context;
    }

    public void Add(Accommodation accommodation)
    {
        _db.Accommodations.Add(accommodation);
        _db.SaveChanges();
    }

    void IAccommodationRepository.Add(Accommodation accommodation)
    {
        _db.Accommodations.Add(accommodation);
        _db.SaveChanges();
    }

    void IAccommodationRepository.AddBooking(Accommodation accommodation)
    {
        _db.SaveChanges();
    }

    Accommodation IAccommodationRepository.GetAccommodation(int id)
    {
        return _db.Accommodations.Include(a => a.Bookings).Single(a => a.Id == id);
    }

    Accommodation IAccommodationRepository.GetAccommodationByDawaCorrelationId(Guid dawaCorrelationId)
    {
        return _db.Accommodations.Include(a => a.Bookings).First(a => a.Address.DawaCorrelationId ==  dawaCorrelationId);
    }

    void IAccommodationRepository.Update(Accommodation accommodation)
    {
        _db.SaveChanges();

    }

    void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowversion)
    {
        _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
        _db.SaveChanges();
    }
}