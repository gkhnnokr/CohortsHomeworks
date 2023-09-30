using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Örnek çalışan listesi
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { No = 1, Name = "Gökhan", Surname = "Okur" },
            new Employee { No = 2, Name = "İlkay", Surname = "Seki" },
            new Employee { No = 2, Name = "Ahmet", Surname = "Yağmur" },
        };


        [HttpGet]
        public IActionResult Get()  // Tüm çalışanları getiren GET endpoint'i
        {
            return Ok(_employees);
        }


        [HttpGet("{id}")] // Belirli bir çalışanı ID'ye göre getiren GET endpoint'i
        public IActionResult GetById(int no)
        {
            var employee = _employees.FirstOrDefault(p => p.No == no);
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
            employee.No = _employees.Count + 1; // Yeni bir kimlik atar.
            _employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.No }, employee); // 201 Created yanıtı
        }

        // Belirli bir çalışanı güncelleyen PUT endpoint'i
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int no, [FromBody] Employee updatedEmployee)
        {
            var employee = _employees.FirstOrDefault(p => p.No == no);
            if (employee == null)
            {
                return NotFound(); // 404 Not Found yanıtı
            }
            employee.Name = updatedEmployee.Name;
            employee.Surname = updatedEmployee.Surname;
            return NoContent(); // 204 No Content yanıtı
        }

        // Belirli bir çalışanı silen DELETE endpoint'i
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int no)
        {
            var employee = _employees.FirstOrDefault(p => p.No == no);
            if (employee == null)
            {
                return NotFound(); // 404 Not Found yanıtı
            }
            _employees.Remove(employee);
            return NoContent(); // 204 No Content yanıtı
        }


        [HttpPatch("{id}")]         // Belirli bir çalışanı güncellemek için PATCH endpoint'i
        public IActionResult PatchEmployee(int no)
        {
            var employee = _employees.FirstOrDefault(p => p.No == no);
            if (employee == null)
            {
                return NotFound();
            }

            // Boş PATCH isteği

            return NoContent();
        }


    }
}

public class Employee
{
    public int No { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}