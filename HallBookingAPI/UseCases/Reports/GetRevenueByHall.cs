using HallBookingAPI.DTOs;
using HallBookingAPI.Persistence.Repositories.IRepositories;

namespace HallBookingAPI.UseCases.Reports;

public class GetRevenueByHall
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IHallRepository _hallRepository;

    public GetRevenueByHall(IBookingRepository bookingRepository, IHallRepository hallRepository)
    {
        _bookingRepository = bookingRepository;
        _hallRepository = hallRepository;
    }

    public List<HallRevenueDto> Execute()
    {
        var bookings = _bookingRepository.GetAll();
        var halls = _hallRepository.GetAll();

        return halls.Select(hall => new HallRevenueDto
        {
            HallId = hall.Id,
            HallName = hall.Name,
            TotalBookings = bookings.Count(b => b.HallId == hall.Id),
            TotalRevenue = bookings.Where(b => b.HallId == hall.Id).Sum(b => b.TotalPrice)
        }).ToList();
    }
}