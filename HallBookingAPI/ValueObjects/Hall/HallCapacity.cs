using HallBookingAPI.Errors;

namespace HallBookingAPI.ValueObjects.Hall;

public class HallCapacity
{
    public int Value { get; }

    private HallCapacity(int value)
    {
        Value = value;
    }

    public static HallCapacity Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException(HallErrors.CapacityMustBePositive.Description);

        return new HallCapacity(value);
    }
}