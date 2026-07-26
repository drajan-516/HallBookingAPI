
using HallBookingAPI.Errors;
using HallBookingAPI.Persistence.Repositories.IRepositories;

namespace HallBookingAPI.Services;

public class HallService
{
    private readonly IHallRepository _hallRepository;
    private readonly IBookingRepository _bookingRepository;

    public HallService(IHallRepository hallRepository, IBookingRepository bookingRepository)
    {
        _hallRepository = hallRepository;
        _bookingRepository = bookingRepository;
    }

    public void DeleteHall(int hallId)
    {
        var hall = _hallRepository.GetById(hallId);
        if (hall == null)
            throw new ArgumentException(HallErrors.NotFound(hallId).Description);

        var hasBookings = _bookingRepository.ExistsForHall(hallId);
        if (hasBookings)
            throw new InvalidOperationException("Cannot delete hall with existing bookings.");

        _hallRepository.Remove(hall);
    }
}