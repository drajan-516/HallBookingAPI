using HallBookingAPI.Errors;
using HallBookingAPI.Exceptions;

namespace HallBookingAPI.ValueObjects.Booking;

public class BookingStartDateTime
{
    public DateTime Value { get; }

    private BookingStartDateTime(DateTime value)
    {
        Value = value;
    }

    public static BookingStartDateTime Create(DateTime value)
    {
        if (value.ToUniversalTime() < DateTime.UtcNow)
            throw new ValidationException(BookingErrors.StartDateInPast.Description);

        return new BookingStartDateTime(value);
    }
}