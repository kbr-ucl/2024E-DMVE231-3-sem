using OnionDemo.Domain.Entity;

namespace OnionDemo.Application;

public interface IAccommodationRepository
{
    Accommodation GetAccommodation(int id);
    void AddBooking(Accommodation accommodation);
    void UpdateBooking(Booking booking, byte[] rowversion);
    void Add(Accommodation accommodation);
    Accommodation GetAccommodationByDawaCorrelationId(Guid requestDawaId);
    void Update(Accommodation accommodation);
}