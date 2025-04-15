using Vypex.CodingChallenge.Application.DTOs;

namespace Vypex.CodingChallenge.Application.Interface
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployeesAsync(string? nameFilter);
        Task<EmployeeDto> GetEmployeesById(Guid employeeId);
        Task AddLeaveAsync(Guid employeeId, CreateLeaveDto leave);
        Task<List<EmployeeDto>> GetEmployeesAsync();
        Task EditLeaveAsync(Guid employeeId, LeaveDayDto leave);
        Task DeleteLeaveAsync(Guid leaveId);
    }
}
