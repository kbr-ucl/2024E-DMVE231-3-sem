using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Application.Command;

public interface IBookingCommand
{
    void CreateBooking(CreateBookingDto bookingDto);
    void UpdateBooking(UpdateBookingDto updateBookingDto);
    void DeleteBooking(DeleteBookingDto deleteBookingDto);
}