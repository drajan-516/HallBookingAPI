using HallBookingAPI.Entities;

namespace HallBookingAPI.Persistence.Repositories.IRepositories;

public interface IBookingRepository
{
    List<Booking> GetAll();
    Booking? GetById(int id);
    void Add(Booking booking);
    void Remove(Booking booking);
    bool ExistsForHall(int hallId);
    bool IsHallAvailable(int hallId, DateTime start, DateTime end);
}