using OnionDemo.Domain.Entity;

namespace OnionDemo.Domain.Test.BookingTests.Fakes;

public class FakeBooking : Booking
{
    public FakeBooking(DateOnly startDate, DateOnly endDate) : base()
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public new void AssureNoOverlapping(IEnumerable<Booking> otherBookings)
    {
        base.AssureNoOverlapping(otherBookings);
    }

    public new void AssureStartDateBeforeEndDate()
    {
        base.AssureStartDateBeforeEndDate();
    }

    public new void AssureBookingSkalVæreIFremtiden(DateOnly now)
    {
        base.AssureBookingSkalVæreIFremtiden(now);
    }
}