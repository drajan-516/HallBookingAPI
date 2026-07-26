using HallBookingAPI.UseCases.Reports;
using Microsoft.AspNetCore.Mvc;

namespace HallBookingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly GetRevenueByHall _getRevenueByHall;

    public ReportsController(GetRevenueByHall getRevenueByHall)
    {
        _getRevenueByHall = getRevenueByHall;
    }

    [HttpGet("revenue-by-hall")]
    public IActionResult GetRevenueByHall()
    {
        var report = _getRevenueByHall.Execute();
        return Ok(report);
    }
}