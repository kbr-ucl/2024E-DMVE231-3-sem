namespace OnionDemo.Application.Command.CommandDto;

public class CreateBookingDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}