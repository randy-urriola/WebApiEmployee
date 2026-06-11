using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEmployee.Features.Employees;

namespace WebApiEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(EmployeeService _service) : ControllerBase
    {
        [HttpGet] // Devuelve todos los empleados
        public async Task<IActionResult> Get()
        {
            var employees = await _service.GetAll();
            return Ok(employees);
        }

        [HttpGet("{Id}")] // Devuelve un empleado
        public async Task<IActionResult> Get(int Id)
        {
            var employee = await _service.GetById(Id);
            return Ok(employee);
        }

        [HttpPost] // 
        public async Task<IActionResult> Post([FromBody]CreateEmployee request)
        {
            await _service.Add(request);
            return Ok();
        }

        [HttpPut] // Agrega un empleado
        public async Task<IActionResult> Put([FromBody] UpdateEmployee request)
        {
            await _service.Update(request);
            return Ok();
        }

        [HttpDelete("{Id}")] // Elimina un empleado
        public async Task<IActionResult> Delete(int Id)
        {
            await _service.Delete(Id);
            return Ok();
        }
    }
}
