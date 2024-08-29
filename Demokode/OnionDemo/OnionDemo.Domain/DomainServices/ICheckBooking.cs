using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.DomainServices
{
    public interface IBookingDomainService
    {
        IEnumerable<Booking> GetOtherBookings(Booking booking);

    }

    public class CheckBooking : IBookingDomainService
    {
        public IEnumerable<Booking> GetOtherBookings(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
