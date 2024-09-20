using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application
{
    public interface IAccommodationRepository
    {
        Accommodation GetAccommodation(int id);
        void AddBooking(Accommodation accommodation);
        void UpdateBooking(Booking booking, byte[] rowversion);
        void Add(Accommodation accommodation);
    }
}
