using HallBookingAPI.Common;
using HallBookingAPI.ValueObjects.Booking;

namespace HallBookingAPI.Entities;

public class Booking : Entity
{
    private Booking() { }

    public int HallId { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public decimal TotalPrice { get; private set; }

    private Booking(int hallId, DateTime start, DateTime end, decimal totalPrice)
    {
        HallId = hallId;
        StartDateTime = start;
        EndDateTime = end;
        TotalPrice = totalPrice;
    }

    public static Booking Create(int hallId, DateTime start, DateTime end, decimal totalPrice)
    {
        var startDateTime = BookingStartDateTime.Create(start);
        var endDateTime = BookingEndDateTime.Create(end, startDateTime.Value);

        return new Booking(hallId, startDateTime.Value, endDateTime.Value, totalPrice);
    }
}