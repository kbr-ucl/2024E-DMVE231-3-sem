using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Domain.Test
{
    public class BookingTests
    {
        //public void Given_Startdate_in_future__Then_Booking_Created()
        //{
        //    // Arrange
        //    var overlappingMock = new Mock<ICheckBooking>();
        //    // Act & Assert
        //    var booking = Booking.Create(DateOnly.FromDateTime(DateTime.Now.AddDays(1)), DateOnly.FromDateTime(DateTime.Now.AddDays(2)), overlappingMock.Object);

        //    //// Assert
        //    Assert.NotNull(booking);

        //    //Assert.Throws<Exception>(() => Booking.Create(DateOnly.FromDateTime(DateTime.Now.AddDays(1)), DateOnly.FromDateTime(DateTime.Now.AddDays(2)), overlappingMock.Object);
        //    //    );
        //}

        //[Theory]
        //public void Given_Booking_Is_In_Past__Then_Exception(DateOnly a, DateOnly b)
        //{
        //    Assert.Throws<Exception>(() => Booking.AssureBookingSkalVæreIFremtiden(a, b));
        //}

        //[Theory]
        //public void Given_Booking_Is_In_Future__Then_Void(DateOnly a, DateOnly b)
        //{
        //    Booking.AssureBookingSkalVæreIFremtiden(a, b));
        //}
    }
}
