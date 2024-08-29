using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;
using OnionDemo.Domain.Test.Fakes;

namespace OnionDemo.Domain.Test
{
    /// <summary>
    /// Se https://www.milanjovanovic.tech/blog/creating-data-driven-tests-with-xunit
    /// Og https://www.c-sharpcorner.com/blogs/datadriven-testing-with-xunit-in-net-80
    /// </summary>
    public class CheckBookingTests
    {
        [Theory]
        [MemberData(nameof(BookingTestDataWithOverlap))]
        public void Given_Booking_Overlap__Then_Returns_True(Booking booking, List<Booking> otherBookings)
        {
            // Arrange
            var sut = new CheckBooking();

            // Act
            var result = sut.IsOverlapping(booking, otherBookings);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(BookingTestDataWithOverlap))]
        public void Given_No_Booking_Overlap__Then_Returns_False(Booking booking, List<Booking> otherBookings)
        {
            // Arrange
            var sut = new CheckBooking();

            // Act
            var result = sut.IsOverlapping(booking, otherBookings);

            // Assert
            Assert.False(result);
        }

        public static IEnumerable<object[]> BookingTestDataWithOverlap()
        {
            var otherBookings = CreateOtherBookings();

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 28),
                    new DateOnly(2024, 8, 29)), otherBookings
            ]; // Overlapper med booking 1

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 20),
                    new DateOnly(2024, 8, 27)), otherBookings
            ]; // Overlapper med booking 1

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 30),
                    new DateOnly(2024, 8, 31)), otherBookings
            ]; // Overlapper med booking 1

            yield return
            [
                new FakeBooking(
                    new DateOnly(2024, 8, 30),
                    new DateOnly(2024, 8, 1)), otherBookings
            ]; // Overlapper med booking 1 og 2

        }

        private static List<Booking> CreateOtherBookings()
        {
            var otherBookings = new List<Booking>(new[]
            {
                new FakeBooking(
                    new DateOnly(2024, 8, 27),
                    new DateOnly(2024, 8, 30))
                ,
                new FakeBooking(
                    new DateOnly(2024, 9, 1),
                    new DateOnly(2024, 9, 7))
                ,
                new FakeBooking(
                    new DateOnly(2024, 9, 10),
                    new DateOnly(2024, 9, 17))
            });
            return otherBookings;
        }
    }
}
