using HallBookingAPI.Errors;

namespace HallBookingAPI.ValueObjects.Services;

public class ServicePrice
{
    public decimal Value { get; }

    private ServicePrice(decimal value)
    {
        Value = value;
    }

    public static ServicePrice Create(decimal value)
    {
        if (value <= 0)
            throw new ArgumentException(ServiceErrors.PriceMustBePositive.Description);

        return new ServicePrice(value);
    }
}