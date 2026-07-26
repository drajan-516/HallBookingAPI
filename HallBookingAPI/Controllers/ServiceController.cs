using HallBookingAPI.Persistence.Repositories.IRepositories;
using HallBookingAPI.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace HallBookingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IServiceRepository _serviceRepository;
    private readonly CreateService _createService;

    public ServicesController(
        IServiceRepository serviceRepository,
        CreateService createService)
    {
        _serviceRepository = serviceRepository;
        _createService = createService;
    }

    public record CreateServiceRequest(string Name, decimal Price);

    [HttpPost]
    public IActionResult Create([FromBody] CreateServiceRequest request)
    {
        var service = _createService.Execute(request.Name, request.Price);
        return Ok(service);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_serviceRepository.GetAll());
    }
}