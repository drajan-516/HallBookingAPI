using HallBookingAPI.Entities;
using HallBookingAPI.Persistence.Repositories.IRepositories;

namespace HallBookingAPI.UseCases.Halls;

public class CreateHall
{
    private readonly IHallRepository _hallRepository;
    private readonly IServiceRepository _serviceRepository;

    public CreateHall(IHallRepository hallRepository, IServiceRepository serviceRepository)
    {
        _hallRepository = hallRepository;
        _serviceRepository = serviceRepository;
    }

    public Hall Execute(string name, decimal pricePerHour, int capacity, List<int> serviceIds)
    {
        var hall = Hall.Create(name, pricePerHour, capacity);

        var services = _serviceRepository.GetByIds(serviceIds ?? new List<int>());
        hall.Services.AddRange(services);

        _hallRepository.Add(hall);
        return hall;
    }
}