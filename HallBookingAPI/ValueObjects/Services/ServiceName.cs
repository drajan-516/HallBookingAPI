using HallBookingAPI.Errors;

namespace HallBookingAPI.ValueObjects.Services;

public class ServiceName
{
    public string Value { get; }

    private ServiceName(string value)
    {
        Value = value;
    }

    public static ServiceName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(ServiceErrors.NameEmpty.Description);

        if (value.Length > 100)
            throw new ArgumentException(ServiceErrors.NameTooLong.Description);

        return new ServiceName(value);
    }
}