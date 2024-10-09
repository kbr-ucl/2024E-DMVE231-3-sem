using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Query.QueryDto;
using OnionDemo.Domain.Entity;
using OnionDemo.Domain.Values;

namespace OnionDemo.Application.Command;

public class AccommodationCommand : IAccommodationCommand
{
    private readonly IAccommodationRepository _repository;
    private readonly IHostRepository _hostRepository;
    private readonly IServiceProvider _serviceProvider;
    private readonly IUnitOfWork _uow;

    public AccommodationCommand(IUnitOfWork uow, IAccommodationRepository repository, IHostRepository hostRepository, IServiceProvider serviceProvider)
    {
        _uow = uow;
        _repository = repository;
        _hostRepository = hostRepository;
        _serviceProvider = serviceProvider;
    }

    void IAccommodationCommand.Create(CreateAccommodationDto createAccommodationDto)
    {
        var host = _hostRepository.Get(createAccommodationDto.HostId);
        var address = Address.Create(createAccommodationDto.Street, createAccommodationDto.Building, createAccommodationDto.ZipCode, createAccommodationDto.City, _serviceProvider);
        var accommodation = Accommodation.Create(host, address);
        _repository.Add(accommodation);
    }

    void IAccommodationCommand.Delete(DeleteAccommodationDto deleteAccommodationDto)
    {
        throw new NotImplementedException();
    }

    void IAccommodationCommand.Update(UpdateAccommodationDto updateAccommodationDto)
    {
        throw new NotImplementedException();
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

    void IAccommodationCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
    {
        throw new NotImplementedException();
    }

    void IAccommodationCommand.SetReviewAndRating(ReviewAndRatingDto reviewAndRatingDto)
    {
        // Load
        Accommodation accommodation = _repository.GetAccommodation(reviewAndRatingDto.AccommodationId);
        // Do

        var booking = accommodation.SetReviewAndRating(reviewAndRatingDto.BokingId, new ReviewAndRating(reviewAndRatingDto.Review, reviewAndRatingDto.Rating));

        // Save
        _repository.UpdateBooking(booking, reviewAndRatingDto.RowVersion);
    }

    void IAccommodationCommand.HandleAddressUpdate(AddressValidatedEventDto request)
    {
        Accommodation accommodation = _repository.GetAccommodationByDawaId(request.DawaId);
        accommodation.UpdateAddressState(request.DawaId, Map(request.ValidationState));
        _repository.Update(accommodation);
    }

    private AddressValidationState Map(AddressValidationStateDto validationState)
    {
        switch (validationState)
        {
            case AddressValidationStateDto.Valid:
                return AddressValidationState.Valid;
            case AddressValidationStateDto.Invalid:
                return AddressValidationState.Invalid;
            case AddressValidationStateDto.Pending:
                return AddressValidationState.Pending;
            case AddressValidationStateDto.Uncertain:
                return AddressValidationState.Uncertain;
            default: 
                throw new ArgumentOutOfRangeException(nameof(validationState), validationState, null);

        }
    }
}
