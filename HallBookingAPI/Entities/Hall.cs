using HallBookingAPI.Common;
using HallBookingAPI.ValueObjects.Hall;

namespace HallBookingAPI.Entities;

public class Hall : Entity
{
    private Hall() { }
    
    public string Name { get; set; }
    public decimal PricePerHour { get; set; }
    public int Capacity { get; set; }
    public List<Service> Services { get; set; } = new();
    
    
    private Hall(string name, decimal pricePerHour, int capacity)
    {
        Name = name;
        PricePerHour = pricePerHour;
        Capacity = capacity;
    }

    //метод для створення зали з використанням перевірок та валідації
    
    public static Hall Create(string name, decimal pricePerHour, int capacity)
    {
        var hallName = HallName.Create(name);
        var price = HallPricePerHour.Create(pricePerHour);
        var hallCapacity = HallCapacity.Create(capacity);

        return new Hall(hallName.Value, price.Value, hallCapacity.Value);
    }
    
    //те саме тільки для оновлення даних
    
    public void Update(string name, decimal pricePerHour, int capacity)
    {
        var hallName = HallName.Create(name);
        var price = HallPricePerHour.Create(pricePerHour);
        var hallCapacity = HallCapacity.Create(capacity);

        Name = hallName.Value;
        PricePerHour = price.Value;
        Capacity = hallCapacity.Value;
    }
}