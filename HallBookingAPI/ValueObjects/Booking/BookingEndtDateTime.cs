using HallBookingAPI.Errors;
using HallBookingAPI.Exceptions;

namespace HallBookingAPI.ValueObjects.Booking;

public class BookingEndDateTime
{
    public DateTime Value { get; }

    private BookingEndDateTime(DateTime value)
    {
        Value = value;
    }

    public static BookingEndDateTime Create(DateTime value, DateTime startValue)
    {
        if (value <= startValue)
            throw new ValidationException(BookingErrors.EndBeforeStart.Description);

        return new BookingEndDateTime(value);
    }
}