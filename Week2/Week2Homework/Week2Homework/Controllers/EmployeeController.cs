using Microsoft.AspNetCore.Mvc;
using Week2Homework.Entities;
using Week2Homework.Repositories;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public IActionResult Get()  // Tüm çalışanları getiren GET endpoint'i
        {
            var employees = _employeeRepository.GetEmployees();
            return Ok(employees);
        }


        [HttpGet("{id}")] // Belirli bir çalışanı ID'ye göre getiren GET endpoint'i
        public IActionResult GetById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(); // 404 Not Found yanıtı
            }
            return Ok(employee); // 200 OK yanıtı
        }

        // Yeni bir çalışan ekleyen POST endpoint'i
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Geçersiz çalışan bilgileri."); // 400 Bad Request yanıtı
            }
            _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee); // 201 Created yanıtı
        }

        // Belirli bir çalışanı güncelleyen PUT endpoint'i
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(); // 404 Not Found yanıtı
            }
            _employeeRepository.UpdateEmployee(id,updatedEmployee);
            return NoContent(); // 204 No Content yanıtı
        }

        // Belirli bir çalışanı silen DELETE endpoint'i
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(); // 404 Not Found yanıtı
            }
            _employeeRepository.DeleteEmployee(id);

            var employees = _employeeRepository.GetEmployees();
            return NoContent(); // 204 No Content yanıtı
        }


        [HttpPatch("{id}")]         // Belirli bir çalışanı güncellemek için PATCH endpoint'i
        public IActionResult PatchEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Boş PATCH isteği

            return NoContent();
        }


    }
}
