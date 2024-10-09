using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using OnionDemo.Domain.Values;

namespace OnionDemo.Domain.Entity;

public class Accommodation : DomainEntity
{
    private readonly List<Booking> _bookings = new List<Booking>();


    protected Accommodation()
    {
    }

    protected Accommodation(Host host, Address address)
    {
        Host = host;
        Address = address;
    }

    public Host Host { get; protected set; }
    public Address Address { get; protected set; }

    public IReadOnlyCollection<Booking> Bookings => _bookings;

    public static Accommodation Create(Host host, Address address)
    {
        return new Accommodation(host, address);
    }

    public void CreateBooking(DateOnly startDate, DateOnly endDate)
    {
        var booking = Booking.Create(startDate, endDate, Bookings);
        _bookings.Add(booking);
    }

    public Booking UpdateBooking(int bookingId, DateOnly startDate, DateOnly endDate)
    {
        var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking == null) throw new ArgumentException("Booking not found");
        booking.Update(startDate, endDate, Bookings);
        return booking;
    }

    public Booking SetReviewAndRating(int bookingId, ReviewAndRating reviewAndRating)
    {
        var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking == null) throw new ArgumentException("Booking not found");
        booking.SetReviewAndRating(reviewAndRating);
        return booking;
    }

    public void UpdateAddressState(Guid requestDawaId, AddressValidationState validationState)
    {
        Address.UpdateValidationState(validationState);
    }
}