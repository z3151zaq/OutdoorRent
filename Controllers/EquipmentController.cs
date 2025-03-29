using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreApi.Data;
using WebCoreApi.Models;

namespace WebCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _db;
        public EquipmentController(IMapper mapper, MyDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetEquipList()
        {
            var equips = await _db.Equipments
                .Where(e => !e.Deleted)
                .ToListAsync();
            var dto = _mapper.Map<List<EquipmentDTO>>(equips);
            return Ok(dto);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddEquipment([FromBody] EquipmentDTO equipment)
        {
            Equipment equip = _mapper.Map<Equipment>(equipment);
            equip.Deleted = false;
            _db.Equipments.Add(equip);
            _db.SaveChanges();
            return new OkObjectResult(true);
        }
    }
}
