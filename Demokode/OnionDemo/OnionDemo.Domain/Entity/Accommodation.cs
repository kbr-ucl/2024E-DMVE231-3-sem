using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Domain.Entity;

public class Accommodation : DomainEntity
{
    protected List<Booking> Bookings { get; set; }
    public Host Host { get; protected set; }

    protected Accommodation(Host host)
    {
        Bookings = [];
        Host = host;
    }

    public IEnumerable<Booking> GetBookings()
    {
        return Bookings.AsEnumerable();
    }

    public static Accommodation Create(Host host)
    {
        return new Accommodation(host);
    }

    public void CreateBooking(DateOnly startDate, DateOnly endDate)
    {
        var booking = Booking.Create(startDate, endDate, GetBookings());
        Bookings.Add(booking);
    }

    public void UpdateBooking(int bookingId, DateOnly startDate, DateOnly endDate)
    {
        var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking == null) throw new ArgumentException("Booking not found");
        booking.Update(startDate, endDate, GetBookings());
    }
}