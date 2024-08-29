using System.Runtime.CompilerServices;
using OnionDemo.Domain.DomainServices;

[assembly: InternalsVisibleTo("OnionDemo.Domain.Test")]
namespace OnionDemo.Domain.Entity;

public class Booking
{
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }


    public static Booking Create(DateOnly startDate, DateOnly endDate, ICheckBooking checkBooking,
        IEnumerable<Booking> otherBookings, DateOnly now)
    {
        // StartDato skal være før EndDato
        if (!(startDate < endDate)) throw new ArgumentException("StartDato skal være før EndDato");

        AssureBookingSkalVæreIFremtiden(startDate, now);

        var booking = new Booking
        {
            StartDate = startDate,
            EndDate = endDate
        };

        // Booking må ikke overlappe med en anden booking
        if (checkBooking.IsOverlapping(booking, otherBookings))
            throw new ArgumentException("Booking overlapper med en anden booking");

        return booking;
    }

    internal static void AssureBookingSkalVæreIFremtiden(DateOnly startDate, DateOnly now)
    {
        // Booking skal være i fremtiden
        if (startDate <= now)
            throw new ArgumentException("Booking skal være i fremtiden");
    }
}