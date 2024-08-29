using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.DomainServices
{
    public interface ICheckBooking
    {
        bool IsOverlapping(Booking booking, IEnumerable<Booking> otherBookings);
    }

    public class CheckBooking : ICheckBooking
    {
        public bool IsOverlapping(Booking booking, IEnumerable<Booking> otherBookings)
        {
            // throw new NotImplementedException("IsOverlapping not implemented yet");
            return true;
        }
    }
}
