using HallBookingAPI.Entities;

namespace HallBookingAPI.Persistence.Repositories.IRepositories;

public interface IServiceRepository
{
    List<Service> GetAll();
    Service? GetById(int id);
    List<Service> GetByIds(List<int> ids);
    void Add(Service service);
    void Remove(Service service);
}