using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Query.QueryDto;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command;

public class AccommodationCommand : IAccommodationCommand
{
    private readonly IAccommodationRepository _repository;
    private readonly IUnitOfWork _uow;

    public AccommodationCommand(IUnitOfWork uow, IAccommodationRepository repository)
    {
        _uow = uow;
        _repository = repository;
    }



    void IAccommodationCommand.CreateBooking(CreateBookingDto bookingDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            Accommodation accommodation= _repository.GetAccommodation(bookingDto.AccommodationId);
            // Do

            accommodation.CreateBooking(bookingDto.StartDate, bookingDto.EndDate);

            // Save
            _repository.AddBooking(accommodation);

            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }

            throw;
        }
    }

    void IAccommodationCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            Accommodation accommodation = _repository.GetAccommodation(updateBookingDto.AccommodationId);
            // Do

            var booking = accommodation.UpdateBooking(updateBookingDto.Id, updateBookingDto.StartDate, updateBookingDto.EndDate);

            // Save
            _repository.UpdateBooking(booking, updateBookingDto.RowVersion);


            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }

            throw;
        }
    }
}
