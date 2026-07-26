using HallBookingAPI.Entities;
using HallBookingAPI.Persistence.Repositories.IRepositories;

namespace HallBookingAPI.UseCases.Services;

public class CreateService
{
    private readonly IServiceRepository _serviceRepository;

    public CreateService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public Service Execute(string name, decimal price)
    {
        var service = Service.Create(name, price);

        _serviceRepository.Add(service);
        return service;
    }
}