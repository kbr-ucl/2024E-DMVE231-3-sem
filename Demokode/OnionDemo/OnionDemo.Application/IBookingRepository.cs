using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application
{
    public interface IBookingRepository
    {
        Booking GetBooking(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking, byte[] rowversion);
    }
}
