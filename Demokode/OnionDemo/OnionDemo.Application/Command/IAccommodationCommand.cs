using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Application.Command
{
    public interface IAccommodationCommand
    {
        void CreateBooking(CreateBookingDto bookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
    }
}
