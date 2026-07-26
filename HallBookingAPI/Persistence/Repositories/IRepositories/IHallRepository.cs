using HallBookingAPI.Entities;

namespace HallBookingAPI.Persistence.Repositories.IRepositories;

public interface IHallRepository
{
    List<Hall> GetAll();
    Hall? GetById(int id);
    void Add(Hall hall);
    void Update(Hall hall);
    void Remove(Hall hall);
}