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
        Accommodation GetBooking(int id);
        void AddBooking(Accommodation booking);
        void UpdateBooking(Accommodation booking, byte[] rowversion);
        Accommodation GetAccommodation(int accommodationId);
    }
}
