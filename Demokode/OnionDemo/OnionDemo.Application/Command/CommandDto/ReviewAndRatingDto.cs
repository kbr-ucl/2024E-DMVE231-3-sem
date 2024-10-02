namespace OnionDemo.Application.Command.CommandDto;

public record ReviewAndRatingDto(int AccommodationId, int BokingId, string Review, int Rating, byte[] RowVersion = null!);