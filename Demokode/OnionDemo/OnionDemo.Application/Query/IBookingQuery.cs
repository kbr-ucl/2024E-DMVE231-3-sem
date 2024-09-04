using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Query.QueryDto;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Query
{
    public interface IBookingQuery
    {
        BookingDto GetBooking(int id);
        IEnumerable<BookingDto> GetBookings();
    }
}
