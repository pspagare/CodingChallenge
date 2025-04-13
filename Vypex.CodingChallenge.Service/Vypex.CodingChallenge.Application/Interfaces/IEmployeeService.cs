using Vypex.CodingChallenge.Application.DTOs;

namespace Vypex.CodingChallenge.Application.Interface
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployeesAsync(string? nameFilter);
        Task<EmployeeDto> GetEmployeesById(Guid employeeId);
        Task AddLeaveAsync(LeaveDayDto leave);
        Task EditLeaveAsync(Guid employeeId, LeaveDayDto leave);
        Task DeleteLeaveAsync(Guid leaveId);
    }
}
