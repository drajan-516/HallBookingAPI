using HallBookingAPI.Errors;

namespace HallBookingAPI.ValueObjects.Hall;

//перевірка назви зали на нуль та довжину
public class HallName
{
    public string Value { get; }

    private HallName(string value)
    {
        Value = value;
    }

    public static HallName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(HallErrors.NameEmpty.Description);

        if (value.Length > 100)
            throw new ArgumentException(HallErrors.NameTooLong.Description);

        return new HallName(value);
    }
}