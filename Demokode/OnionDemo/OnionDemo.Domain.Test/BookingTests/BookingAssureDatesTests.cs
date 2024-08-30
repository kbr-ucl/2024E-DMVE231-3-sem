using OnionDemo.Domain.Test.BookingTests.Fakes;

namespace OnionDemo.Domain.Test.BookingTests;

public class BookingAssureDatesTests
{
    [Theory]
    [InlineData("2024-08-1", "2024-08-2")]
    public void Given_Startdate_in_future__Then_Return_Void(string now, string startDate)
    {
        // Arrange
        var sut = new FakeBooking(DateOnly.Parse(startDate), DateOnly.MaxValue);

        // Act & Assert
        sut.AssureBookingSkalVæreIFremtiden(DateOnly.Parse(now));
    }

    [Theory]
    [InlineData("2024-08-2", "2024-07-1")]
    [InlineData("2024-08-2", "2024-08-1")]
    [InlineData("2024-08-2", "2024-08-2")]
    public void Given_Booking_Is_In_Past_Or_ToDay__Then_Exception(string now, string startDate)
    {
        // Arrange
        var sut = new FakeBooking(DateOnly.Parse(startDate), DateOnly.MaxValue);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => sut.AssureBookingSkalVæreIFremtiden(DateOnly.Parse(now)));
    }

    [Theory]
    [InlineData("2024-08-1", "2024-08-2")]
    public void Given_StartDate_Before_EndDate__Then_Return_Void(string startDate, string endDate)
    {
        // Arrange
        var sut = new FakeBooking(DateOnly.Parse(startDate), DateOnly.Parse(endDate));

        // Act & Assert
        sut.AssureStartDateBeforeEndDate();
    }

    [Theory]
    [InlineData("2024-09-3", "2024-08-2")]
    [InlineData("2024-08-3", "2024-08-2")]
    [InlineData("2024-08-2", "2024-08-2")]
    public void Given_StartDate_After_Or_Equal_EndDate__Then_Exception(string startDate, string endDate)
    {
        // Arrange
        var sut = new FakeBooking(DateOnly.Parse(startDate), DateOnly.Parse(endDate));

        // Act & Assert
        Assert.Throws<ArgumentException>(() => sut.AssureStartDateBeforeEndDate());
    }
}