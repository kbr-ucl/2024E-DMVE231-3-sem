using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.Helpers;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command;

public class BookingCommand : IBookingCommand
{
    private readonly IBookingDomainService _domainService;
    private readonly IBookingRepository _repository;
    private readonly IUnitOfWork _uow;

    public BookingCommand(IUnitOfWork uow, IBookingRepository repository, IBookingDomainService domainService)
    {
        _uow = uow;
        _repository = repository;
        _domainService = domainService;
    }

    void IBookingCommand.CreateBooking(CreateBookingDto bookingDto)
    {
        try
        {
            _uow.BeginTransaction();

            // Do
            var booking = Booking.Create(bookingDto.StartDate, bookingDto.EndDate, _domainService);

            // Save
            _repository.AddBooking(booking);

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

    void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            var booking = _repository.GetBooking(updateBookingDto.Id);

            // Do
            booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);

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

    void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
    {
        // Load
        // Do
        // Save
    }
}