using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCoreApi.Data;
using WebCoreApi.Models;

namespace WebCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var testUser = new User()
            {
                Id = 1,
                Name = "test",
                Age = 30
            };
            var dto = _mapper.Map<UserDTO>(testUser);
            return Ok(dto);
        }
    }
}
