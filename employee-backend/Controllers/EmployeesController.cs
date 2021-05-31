using employee_backend.Models;
using employee_backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeModel>> GetEmployees() {
            return await _employeeRepository.GetAll();
        }

        [HttpGet("searchLastName/{searchName}")]
        public async Task<IEnumerable<EmployeeModel>> SearchForLastName(string searchName)
        {
            return await _employeeRepository.SearchForLastName(searchName);
        }

        [HttpGet("{id}")]   
        public async Task<ActionResult<EmployeeModel>> GetEmployees(int id)
        {
            return await _employeeRepository.Get(id);

        }

        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployee([FromBody] EmployeeModel employee)
        {
            var newEmployee = await _employeeRepository.Create(employee);
            return CreatedAtAction(nameof(GetEmployees), new { Id = newEmployee.Id }, newEmployee);

        }

        [HttpPut]
        public async Task<ActionResult> PutEmployee(int id, [FromBody] EmployeeModel employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeRepository.Update(employee);

            // Return 201 status if ok
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var employeeToDelete = await _employeeRepository.Get(id);

            // Case not found
            if (employeeToDelete == null)
                return NotFound();

            // Delete and return no content status
            await _employeeRepository.Delete(employeeToDelete.Id);
            return NoContent();
        }
    }
}
