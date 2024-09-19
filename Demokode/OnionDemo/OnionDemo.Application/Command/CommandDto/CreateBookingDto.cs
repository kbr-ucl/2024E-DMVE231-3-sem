namespace OnionDemo.Application.Command.CommandDto;

public class CreateBookingDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int AccommodationId { get; set; }
}