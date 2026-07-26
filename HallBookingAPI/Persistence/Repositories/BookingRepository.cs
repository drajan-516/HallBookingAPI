using HallBookingAPI.Entities;
using HallBookingAPI.Persistence.Repositories.IRepositories;

namespace HallBookingAPI.Persistence.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly HallDbContext _context;

    public BookingRepository(HallDbContext context)
    {
        _context = context;
    }

    public List<Booking> GetAll() => _context.Bookings.ToList();
    public Booking? GetById(int id) => _context.Bookings.Find(id);

    public void Add(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();
    }

    public void Remove(Booking booking)
    {
        _context.Bookings.Remove(booking);
        _context.SaveChanges();
    }

    public bool ExistsForHall(int hallId) =>
        _context.Bookings.Any(b => b.HallId == hallId);

    public bool IsHallAvailable(int hallId, DateTime start, DateTime end)
    {
        var hasOverlap = _context.Bookings.Any(b =>
            b.HallId == hallId &&
            b.StartDateTime < end &&
            b.EndDateTime > start);

        return !hasOverlap;
    }
}