using HallBookingAPI.Persistence.Repositories.IRepositories;
using HallBookingAPI.UseCases.Halls;
using Microsoft.AspNetCore.Mvc;

namespace HallBookingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HallsController : ControllerBase
{
    private readonly IHallRepository _hallRepository;
    private readonly CreateHall _createHall;
    private readonly DeleteHall _deleteHall;
    private readonly SearchAvailableHalls _searchAvailableHalls;

    public HallsController(
        IHallRepository hallRepository,
        CreateHall createHall,
        DeleteHall deleteHall,
        SearchAvailableHalls searchAvailableHalls)
    {
        _hallRepository = hallRepository;
        _createHall = createHall;
        _deleteHall = deleteHall;
        _searchAvailableHalls = searchAvailableHalls;
    }

    public record CreateHallRequest(string Name, decimal PricePerHour, int Capacity, List<int>? ServiceIds);

    [HttpPost]
    public IActionResult Create([FromBody] CreateHallRequest request)
    {
        var hall = _createHall.Execute(
            request.Name,
            request.PricePerHour,
            request.Capacity,
            request.ServiceIds ?? new List<int>()
        );
        return Ok(hall);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _deleteHall.Execute(id);
        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_hallRepository.GetAll());
    }
    
    [HttpGet("available")]
    public IActionResult SearchAvailable([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] int capacity)
    {
        var halls = _searchAvailableHalls.Execute(start, end, capacity);
        return Ok(halls);
    }
}