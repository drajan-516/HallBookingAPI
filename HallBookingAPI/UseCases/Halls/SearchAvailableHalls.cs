using HallBookingAPI.Entities;
using HallBookingAPI.Persistence.Repositories.IRepositories;

namespace HallBookingAPI.UseCases.Halls;

public class SearchAvailableHalls
{
    private readonly IHallRepository _hallRepository;
    private readonly IBookingRepository _bookingRepository;

    public SearchAvailableHalls(IHallRepository hallRepository, IBookingRepository bookingRepository)
    {
        _hallRepository = hallRepository;
        _bookingRepository = bookingRepository;
    }

    public List<Hall> Execute(DateTime start, DateTime end, int minCapacity)
    {
        var allHalls = _hallRepository.GetAll();

        var busyHallIds = allHalls
            .Where(h => !_bookingRepository.IsHallAvailable(h.Id, start, end))
            .Select(h => h.Id)
            .ToHashSet();

        return allHalls
            .Where(h => h.Capacity >= minCapacity && !busyHallIds.Contains(h.Id))
            .ToList();
    }
}