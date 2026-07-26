using HallBookingAPI.Entities;
using HallBookingAPI.Persistence.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HallBookingAPI.Persistence.Repositories;

public class HallRepository : IHallRepository
{
    private readonly HallDbContext _context;

    public HallRepository(HallDbContext context)
    {
        _context = context;
    }

    public List<Hall> GetAll() => 
        _context.Halls.Include(h => h.Services).ToList();

    public Hall? GetById(int id) => 
        _context.Halls.Include(h => h.Services).FirstOrDefault(h => h.Id == id);

    public void Add(Hall hall)
    {
        _context.Halls.Add(hall);
        _context.SaveChanges();
    }

    public void Update(Hall hall)
    {
        _context.SaveChanges();
    }

    public void Remove(Hall hall)
    {
        hall.Services.Clear();
        _context.SaveChanges();

        _context.Halls.Remove(hall);
        _context.SaveChanges();
    }
}