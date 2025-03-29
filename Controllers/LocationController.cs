using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreApi.Data;
using WebCoreApi.Models;

namespace WebCoreApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly MyDbContext _db;

    public LocationController(IMapper mapper, MyDbContext db)
    {
        _mapper = mapper;
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocationList()
    {
        var locations = await _db.Locations.Include(l => l.Manager).ToListAsync();
        var dto = _mapper.Map<List<LocationDTO>>(locations);
        return Ok(dto);
    }
    [HttpPost]
    public async Task<IActionResult> AddLocation([FromBody] CreateLocationDTO newLocationDto)
    {
        Location loc = new Location()
        {
            Name = newLocationDto.Name,
            LocationDetail = newLocationDto.LocationDetail,
            ManagerId = newLocationDto.ManagerId,
        };
        _db.Locations.Add(loc);
        _db.SaveChanges();
        return new OkObjectResult(loc.Id);
    }
}