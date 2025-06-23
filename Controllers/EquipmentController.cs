using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreApi.Data;
using WebCoreApi.Models;
using WebCoreApi.Repository.Interfaces;
using WebCoreApi.Services;

namespace WebCoreApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly MyDbContext _db;
    private readonly EquipmentService _equipmentService;
    
    public EquipmentController(IMapper mapper, MyDbContext db, EquipmentService equipmentService)
    {
        _mapper = mapper;
        _db = db;
        _equipmentService = equipmentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEquipList()
    {
        var equipmentDtos = await _db.Equipments
            .Include(e => e.LocationDetail)
            .ThenInclude(l => l.Manager)
            .ProjectTo<EquipmentDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();
        return Ok(equipmentDtos);
    }
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> AddEquipment([FromBody] EquipmentDTO equipment)
    {
        Equipment equip = _mapper.Map<Equipment>(equipment);
        equip.Deleted = false;
        _equipmentService.AddEquipment(equip);
        return new OkObjectResult(true);
    }
}

