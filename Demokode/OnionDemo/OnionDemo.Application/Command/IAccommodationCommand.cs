using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Application.Command
{
    public interface IAccommodationCommand
    {
        void Create(CreateAccommodationDto createAccommodationDto);
        void Update(UpdateAccommodationDto updateAccommodationDto);
        void Delete(DeleteAccommodationDto deleteAccommodationDto);
        void CreateBooking(CreateBookingDto bookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);
        void SetReviewAndRating(ReviewAndRatingDto reviewAndRatingDto);
    }
}
