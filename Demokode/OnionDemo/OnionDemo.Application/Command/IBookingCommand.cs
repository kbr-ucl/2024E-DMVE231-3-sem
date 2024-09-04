namespace OnionDemo.Application.Command;

public interface IBookingCommand
{
    void CreateBooking(CreateBookingDto bookingDto);
    void UpdateBooking(UpdateBookingDto updateBookingDto);
    void DeleteBooking(DeleteBookingDto deleteBookingDto);
}

public class DeleteBookingDto
{
}

public class UpdateBookingDto
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public byte[] RowVersion { get; set; }
}

public class CreateBookingDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}