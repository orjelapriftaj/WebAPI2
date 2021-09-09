using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
       public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        
           [HttpGet]
           [Authorize]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return  await _employee.Get();
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Employee>> GetEmployees(int id)
        {
            return await _employee.Get(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Employee>> PostEmployees([FromBody] Employee employee)
        {
            var newEmployee = await _employee.Create(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = newEmployee.ID }, newEmployee);
        }

        [HttpPut]
        [Authorize]
       public async Task <ActionResult> PutEmployees(int id, [FromBody] Employee employee)
        {
            if(id!= employee.ID)
            {
                return BadRequest();
            }
            await _employee.Create(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var employeeToDelete = await _employee.Get(id);
            if (employeeToDelete == null)
                return NotFound();

            await _employee.Delete(employeeToDelete.ID);
            return NoContent();

        }
    }
}
