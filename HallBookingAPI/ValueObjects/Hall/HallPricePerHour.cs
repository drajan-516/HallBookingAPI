using HallBookingAPI.Errors;

namespace HallBookingAPI.ValueObjects.Hall;

public class HallPricePerHour
{
    public decimal Value { get; }

    private HallPricePerHour(decimal value)
    {
        Value = value;
    }

    public static HallPricePerHour Create(decimal value)
    {
        if (value <= 0)
            throw new ArgumentException(HallErrors.PriceMustBePositive.Description);

        return new HallPricePerHour(value);
    }
}