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
        public async Task<ActionResult<IList<EmployeeDto>>> GetEmployees([FromQuery] string? name)
        {
            var employees = await employeeService.GetEmployeesAsync(name);
            return Ok(employees);
        }
        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(Guid id)
        {
            var employee = await employeeService.GetEmployeesById(id);

            if (employee == null) return NotFound();

            return employee;
        }

        /// <summary>
        ///  AddLeave POST: api/Employees/{id}/leaves
        /// </summary>
        /// <param name="id"></param>
        /// <param name="leave"></param>
        /// <returns></returns>
        [HttpPost("{id}/leaves")]
        public async Task<ActionResult<LeaveDayDto>> AddLeaveAsync(LeaveDayDto leave)
        {            
            await employeeService.AddLeaveAsync(leave);
            return Ok(leave);
        }

        /// <summary>
        /// Edit LeaveDay
        /// </summary>
        /// <param name="id"></param>
        /// <param name="leaveId"></param>
        /// <param name="updatedLeaveDay"></param>
        /// <returns></returns>
        [HttpPut("{id}/leaves")]
        public async Task<IActionResult> EditLeave(Guid id, [FromBody] LeaveDayDto leave)
        {
            await employeeService.EditLeaveAsync(id, leave);
            return Ok();
        }

        /// <summary>
        /// Delete Leave
        /// </summary>
        /// <param name="id"></param>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        [HttpDelete("{id}/leaves/{leaveId}")]
        public async Task<IActionResult> DeleteLeave(Guid leaveId)
        {
            await employeeService.DeleteLeaveAsync(leaveId);
            return Ok();
        }
    }
}
