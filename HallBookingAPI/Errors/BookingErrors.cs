using HallBookingAPI.Shared;

namespace HallBookingAPI.Errors;

public class BookingErrors
{
    public static readonly Error StartDateInPast =
        Error.Validation("Booking.StartDateInPast", "Start date cannot be in the past.");

    public static readonly Error EndBeforeStart =
        Error.Validation("Booking.EndBeforeStart", "End time must be later than start time.");

    public static Error HallNotAvailable(int hallId) =>
        Error.Failure("Booking.HallNotAvailable", $"Hall with id {hallId} is not available for the selected time.");
}