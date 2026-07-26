namespace HallBookingAPI.Shared;

//для помилок використовую factory pattern, тобто тут основні помилки, а в окремих
//файлах вже специфічні
public class Error
{
    public string? Code { get; }
    public string? Description { get; }
    public ErrorType Type { get; }
    
    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }
    
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    public static Error Failure(string code, string description) =>
        new(code, description, ErrorType.Failure);

    public static Error Validation(string code, string description) =>
        new(code, description, ErrorType.Validation);

    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);
}