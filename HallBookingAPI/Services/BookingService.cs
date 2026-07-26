using HallBookingAPI.Entities;
using HallBookingAPI.Errors;
using HallBookingAPI.Persistence.Repositories.IRepositories;

namespace HallBookingAPI.UseCases.Services;

public class BookingService
{
    private readonly IHallRepository _hallRepository;
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IHallRepository hallRepository, IBookingRepository bookingRepository)
    {
        _hallRepository = hallRepository;
        _bookingRepository = bookingRepository;
    }

    public Booking CreateBooking(int hallId, DateTime start, DateTime end)
    {
        var hall = _hallRepository.GetById(hallId);
        if (hall == null)
            throw new ArgumentException(HallErrors.NotFound(hallId).Description);

        var isAvailable = _bookingRepository.IsHallAvailable(hallId, start, end);
        if (!isAvailable)
            throw new InvalidOperationException(BookingErrors.HallNotAvailable(hallId).Description);

        var booking = Booking.Create(hallId, start, end);

        _bookingRepository.Add(booking);
        return booking;
    }
}