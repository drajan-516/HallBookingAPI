using HallBookingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HallBookingAPI.Persistence;

public class HallDbContext : DbContext
{
    public HallDbContext(DbContextOptions<HallDbContext> options) : base(options) { }

    public DbSet<Hall> Halls { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    
    public DbSet<Service> Service { get; set; }
}