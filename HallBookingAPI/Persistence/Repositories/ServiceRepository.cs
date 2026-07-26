using HallBookingAPI.Entities;
using HallBookingAPI.Persistence.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HallBookingAPI.Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly HallDbContext _context;

    public ServiceRepository(HallDbContext context)
    {
        _context = context;
    }

    public List<Service> GetAll() => _context.Services.ToList();

    public Service? GetById(int id) => _context.Services.Find(id);

    public List<Service> GetByIds(List<int> ids) =>
        _context.Services.Where(s => ids.Contains(s.Id)).ToList();

    public void Add(Service service)
    {
        _context.Services.Add(service);
        _context.SaveChanges();
    }

    public void Remove(Service service)
    {
        _context.Services.Remove(service);
        _context.SaveChanges();
    }
}