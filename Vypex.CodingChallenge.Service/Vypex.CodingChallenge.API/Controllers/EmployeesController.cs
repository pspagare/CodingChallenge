using Microsoft.AspNetCore.Mvc;
using Vypex.CodingChallenge.Application.DTOs;
using Vypex.CodingChallenge.Application.Interface;

namespace Vypex.CodingChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {

        [HttpGet(Name = "GetEmployees")]
        public async Task<ActionResult<IList<EmployeeDto>>> GetEmployees()
        {
            var employees = await employeeService.GetEmployeesAsync();

            if (employees == null) {return NotFound();}

            return Ok(employees);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IList<EmployeeDto>>> GetEmployees(string name)
        {
            var employees = await employeeService.GetEmployeesAsync(name);

            if (employees == null) { return NotFound(); }

            return Ok(employees);
        }

        [HttpPost("{id:guid}/leaves")]
        public async Task<ActionResult<CreateLeaveDto>> AddLeaveAsync(Guid id, CreateLeaveDto leave)
        {            
            await employeeService.AddLeaveAsync(id, leave);

            return Ok(leave);
        }

        [HttpPut("{id:guid}/leaves")]
        public async Task<IActionResult> EditLeave(Guid id, LeaveDayDto leave)
        {
            await employeeService.EditLeaveAsync(id, leave);

            return NoContent();
        }

        [HttpDelete("{id:guid}/leaves/{leaveId:guid}")]
        public async Task<IActionResult> DeleteLeave(Guid id, Guid leaveId)
        {
            await employeeService.DeleteLeaveAsync(leaveId);

            return NoContent();
        }
    }
}
