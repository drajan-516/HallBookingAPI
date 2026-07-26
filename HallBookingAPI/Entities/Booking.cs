using HallBookingAPI.Common;
using HallBookingAPI.ValueObjects.Booking;

namespace HallBookingAPI.Entities;

public class Booking : Entity
{
    private Booking() { }
    
    public int HallId { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    private Booking(int hallId, DateTime start, DateTime end)
    {
        HallId = hallId;
        StartDateTime = start;
        EndDateTime = end;
    }

    public static Booking Create(int hallId, DateTime start, DateTime end)
    {
        var startDateTime = BookingStartDateTime.Create(start);
        var endDateTime = BookingEndDateTime.Create(end, start);

        return new Booking(hallId, startDateTime.Value, endDateTime.Value);
    }
}