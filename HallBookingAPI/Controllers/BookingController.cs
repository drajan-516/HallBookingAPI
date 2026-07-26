using HallBookingAPI.UseCases.Bookings;
using HallBookingAPI.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace HallBookingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly CreateBooking _createBooking;

    public BookingsController(CreateBooking createBooking)
    {
        _createBooking = createBooking;
    }

    public record CreateBookingRequest(
        int HallId,
        DateTime StartDateTime,
        DateTime EndDateTime,
        List<int>? ServiceIds
    );

    [HttpPost]
    public IActionResult Create([FromBody] CreateBookingRequest request)
    {
        var (booking, totalPrice) = _createBooking.Execute(
            request.HallId,
            request.StartDateTime,
            request.EndDateTime,
            request.ServiceIds ?? new List<int>()
        );

        return Ok(new
        {
            bookingId = booking.Id,
            hallId = booking.HallId,
            start = booking.StartDateTime,
            end = booking.EndDateTime,
            totalPrice
        });
    }
}