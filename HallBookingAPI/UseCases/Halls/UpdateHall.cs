using HallBookingAPI.Errors;
using HallBookingAPI.Persistence.Repositories.IRepositories;

namespace HallBookingAPI.UseCases.Halls;

public class UpdateHall
{
    private readonly IHallRepository _hallRepository;
    private readonly IServiceRepository _serviceRepository;

    public UpdateHall(IHallRepository hallRepository, IServiceRepository serviceRepository)
    {
        _hallRepository = hallRepository;
        _serviceRepository = serviceRepository;
    }

    public void Execute(int hallId, string name, decimal pricePerHour, int capacity, List<int> serviceIds)
    {
        var hall = _hallRepository.GetById(hallId);
        if (hall == null)
            throw new ArgumentException(HallErrors.NotFound(hallId).Description);

        hall.Update(name, pricePerHour, capacity);

        var services = _serviceRepository.GetByIds(serviceIds);
        hall.Services.Clear();
        hall.Services.AddRange(services);

        _hallRepository.Update(hall);
    }
}