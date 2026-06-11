using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEmployee.Features.Positions;

namespace WebApiEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController(PositionService _service) : ControllerBase
    {
        [HttpGet] // Devuelve todas las posiciones
        public async Task<IActionResult> Get()
        {
            var positions = await _service.GetAll();
            return Ok(positions);
        }
    }
}
