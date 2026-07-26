using HallBookingAPI.Entities;
using HallBookingAPI.Errors;
using HallBookingAPI.Exceptions;
using HallBookingAPI.Persistence.Repositories.IRepositories;
using HallBookingAPI.UseCases.Pricing;

namespace HallBookingAPI.UseCases.Bookings;

public class CreateBooking
{
    private readonly IHallRepository _hallRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IServiceRepository _serviceRepository;

    public CreateBooking(
        IHallRepository hallRepository,
        IBookingRepository bookingRepository,
        IServiceRepository serviceRepository)
    {
        _hallRepository = hallRepository;
        _bookingRepository = bookingRepository;
        _serviceRepository = serviceRepository;
    }

    public Booking Execute(int hallId, DateTime start, DateTime end, List<int> serviceIds)
    {
        var hall = _hallRepository.GetById(hallId);
        if (hall == null)
            throw new NotFoundException(HallErrors.NotFound(hallId).Description);

        var isAvailable = _bookingRepository.IsHallAvailable(hallId, start, end);
        if (!isAvailable)
            throw new InvalidOperationException(BookingErrors.HallNotAvailable(hallId).Description);

        var selectedServices = _serviceRepository.GetByIds(serviceIds ?? new List<int>());

        var hallCost = PricingCalculator.CalculateHallCost(hall.PricePerHour, start, end);
        var servicesCost = selectedServices.Sum(s => s.Price);
        var totalPrice = hallCost + servicesCost;

        var booking = Booking.Create(hallId, start, end, totalPrice);
        _bookingRepository.Add(booking);

        return booking;
    }
}