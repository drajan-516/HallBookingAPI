using HallBookingAPI.Shared;

namespace HallBookingAPI.Errors;

public class HallErrors
{
    //hallName
    
    public static readonly Error NameEmpty =
        Error.Validation("Hall.NameEmpty", "Hall name cannot be empty.");

    public static readonly Error NameTooLong =
        Error.Validation("Hall.NameTooLong", "Hall name is too long.");

    //hallPricePerHour
    
    public static readonly Error PriceMustBePositive =
        Error.Validation("Hall.PriceMustBePositive", "Price per hour must be greater than zero.");
    
    //hallCapacity
    
    public static readonly Error CapacityMustBePositive =
        Error.Validation("Hall.CapacityMustBePositive", "Capacity must be greater than zero.");
    
    public static Error NotFound(int id) =>
        Error.NotFound("Hall.NotFound", $"Hall with id {id} was not found.");
}