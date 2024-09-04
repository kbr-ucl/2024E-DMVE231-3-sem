using OnionDemo.Domain.Entity;

namespace OnionDemo.Domain.DomainServices;

public interface IBookingDomainService
{
    IEnumerable<Booking> GetOtherBookings(Booking booking);

}