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

    void IAccommodationRepository.AddBooking(Accommodation accommodation)
    {
        _db.SaveChanges();
    }

    Accommodation IAccommodationRepository.GetAccommodation(int id)
    {
        return _db.Accommodations.Single(a => a.Id == id);
    }

    void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowversion)
    {
        _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
        _db.SaveChanges();
    }
}