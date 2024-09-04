namespace OnionDemo.Application.Command.CommandDto;

public class UpdateBookingDto
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public byte[] RowVersion { get; set; } = null!;
}