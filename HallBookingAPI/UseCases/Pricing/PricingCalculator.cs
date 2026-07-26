namespace HallBookingAPI.UseCases.Pricing;

public static class PricingCalculator
{
    public static decimal CalculateHallCost(decimal pricePerHour, DateTime start, DateTime end)
    {
        decimal totalCost = 0;
        var current = start;

        while (current < end)
        {
            var segmentEnd = GetNextBoundary(current);
            if (segmentEnd > end)
                segmentEnd = end;

            var hours = (decimal)(segmentEnd - current).TotalHours;
            var multiplier = GetMultiplier(current.TimeOfDay);

            totalCost += pricePerHour * hours * multiplier;

            current = segmentEnd;
        }

        return totalCost;
    }
    
    private static DateTime GetNextBoundary(DateTime current)
    {
        var boundaries = new[] { 6, 9, 12, 14, 18, 23 };
        var time = current.TimeOfDay;

        foreach (var hour in boundaries)
        {
            var boundaryTime = TimeSpan.FromHours(hour);
            if (boundaryTime > time)
                return current.Date + boundaryTime;
        }
        
        return current.Date.AddDays(1).AddHours(6);
    }

    private static decimal GetMultiplier(TimeSpan time)
    {
        if (time >= TimeSpan.FromHours(6) && time < TimeSpan.FromHours(9))
            return 0.9m;

        if (time >= TimeSpan.FromHours(9) && time < TimeSpan.FromHours(12))
            return 1.0m;

        if (time >= TimeSpan.FromHours(12) && time < TimeSpan.FromHours(14))
            return 1.15m;

        if (time >= TimeSpan.FromHours(14) && time < TimeSpan.FromHours(18))
            return 1.0m;

        if (time >= TimeSpan.FromHours(18) && time < TimeSpan.FromHours(23))
            return 0.8m;

        return 1.0m;
    }
}