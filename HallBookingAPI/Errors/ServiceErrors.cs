using HallBookingAPI.Shared;

namespace HallBookingAPI.Errors;

public class ServiceErrors
{
    public static readonly Error NameEmpty =
        Error.Validation("Service.NameEmpty", "Service name cannot be empty.");

    public static readonly Error NameTooLong =
        Error.Validation("Service.NameTooLong", "Service name is too long.");
    
    public static readonly Error PriceMustBePositive =
        Error.Validation("Service.PriceMustBePositive", "Price must be greater than zero.");
}