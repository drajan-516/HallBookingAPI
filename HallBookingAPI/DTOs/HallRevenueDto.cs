namespace HallBookingAPI.DTOs;

public class HallRevenueDto
{
    public int HallId { get; set; }
    public string HallName { get; set; }
    public int TotalBookings { get; set; }
    public decimal TotalRevenue { get; set; }
}