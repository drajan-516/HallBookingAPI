using HallBookingAPI.Entities;

namespace HallBookingAPI.Persistence;

public class HallDbSeeder
{
    public static void Seed(HallDbContext context)
    {
        if (context.Halls.Any() || context.Services.Any())
            return;

        var projector = Service.Create("Проєктор", 500m);
        var wifi = Service.Create("Wi-Fi", 300m);
        var sound = Service.Create("Звук", 700m);

        context.Services.AddRange(projector, wifi, sound);

        var hallA = Hall.Create("Зал А", 2000m, 50);
        var hallB = Hall.Create("Зал B", 3500m, 100);
        var hallC = Hall.Create("Зал C", 1500m, 30);

        // прив'язкп послуг до кожного залу
        hallA.Services.AddRange(new[] { projector, wifi });
        hallB.Services.AddRange(new[] { projector, wifi, sound });
        hallC.Services.AddRange(new[] { wifi });

        context.Halls.AddRange(hallA, hallB, hallC);

        context.SaveChanges();
    }
}