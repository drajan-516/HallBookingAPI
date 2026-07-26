using HallBookingAPI.Common;
using HallBookingAPI.ValueObjects.Services;

namespace HallBookingAPI.Entities;

public class Service : Entity
{
    private Service()
    {
    }

    public string Name { get; private set; }
    public decimal Price { get; private set; }

    private Service(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public static Service Create(string name, decimal price)
    {
        var serviceName = ServiceName.Create(name);
        var servicePrice = ServicePrice.Create(price);

        return new Service(serviceName.Value, servicePrice.Value);
    }
    
    public void Update(string name, decimal price)
    {
        var serviceName = ServiceName.Create(name);
        var servicePrice = ServicePrice.Create(price);

        Name = serviceName.Value;
        Price = servicePrice.Value;
    }
}    