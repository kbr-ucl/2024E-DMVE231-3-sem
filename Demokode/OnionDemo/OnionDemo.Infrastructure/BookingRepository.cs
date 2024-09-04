using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookMyHomeContext _db;
        public BookingRepository(BookMyHomeContext context)
        {
            _db = context;
        }

        void IBookingRepository.AddBooking(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }

        Booking IBookingRepository.GetBooking(int id)
        {
            return _db.Bookings.Single(a => a.Id == id);
        }

        void IBookingRepository.UpdateBooking(Booking booking, byte[] rowversion)
        {

            _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
            _db.SaveChanges();
        }
    }
}
