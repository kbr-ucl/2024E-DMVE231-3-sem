using System.Runtime.CompilerServices;
using OnionDemo.Domain.DomainServices;

[assembly: InternalsVisibleTo("OnionDemo.Domain.Test")]
namespace OnionDemo.Domain.Entity;

public class Booking
{
    public int Id { get; protected set; }
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }

    protected Booking(){}

    private Booking(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        AssureStartDateBeforeEndDate(startDate, endDate);
        AssureBookingSkalVæreIFremtiden(startDate, DateOnly.FromDateTime(DateTime.Now));

        StartDate = startDate;
        EndDate = endDate;

        AssureNoOverlapping(bookingDomainService.GetOtherBookings(this));

    }

    protected void AssureStartDateBeforeEndDate(DateOnly startDate, DateOnly endDate)
    {
        if (!(startDate < endDate)) throw new ArgumentException("StartDato skal være før EndDato");
    }

    public static Booking Create(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
    {
        return new Booking(startDate, endDate, bookingDomainService);
    }

    protected void AssureBookingSkalVæreIFremtiden(DateOnly startDate, DateOnly now)
    {
        // Booking skal være i fremtiden
        if (startDate <= now)
            throw new ArgumentException("Booking skal være i fremtiden");
    }

    protected void AssureNoOverlapping(IEnumerable<Booking> otherBookings)
    {
        if (otherBookings.Any(b => b.StartDate <= EndDate && b.EndDate >= StartDate)) 
            throw new Exception("Booking overlapper med en anden booking");
    }
}