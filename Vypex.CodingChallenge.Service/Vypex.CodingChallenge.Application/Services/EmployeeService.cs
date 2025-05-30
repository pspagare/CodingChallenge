﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Application.DTOs;
using Vypex.CodingChallenge.Application.Interface;
using Vypex.CodingChallenge.Domain.Models;
using Vypex.CodingChallenge.Infrastructure.Data;

namespace Vypex.CodingChallenge.Application.Services
{
    public class EmployeeService(CodingChallengeContext context) : IEmployeeService
    {
        /// <summary>
        /// Add Leave
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="leave"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task AddLeaveAsync(Guid employeeId, CreateLeaveDto leave)
        {
            var employee = await context.Employees.Include(e => e.Leaves).FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null) throw new ArgumentException("Employee not found");
            if (employee.Leaves == null) throw new ArgumentException("Leave entry not found");
           
            if (employee.Leaves.Any(ld => IsOverlapping(leave, ld)))
                throw new ArgumentException("Leave dates overlap with existing leave");

            employee.Leaves.Add(new LeaveDay
            {
                StartDate = leave.StartDate,
                EndDate = leave.EndDate               
            });            
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //TODO: log error
                throw;
            }
            
        }
       
        public async Task DeleteLeaveAsync(Guid leaveId)
        {
            var leave = await context.LeaveDays.FirstOrDefaultAsync(ld => ld.Id == leaveId);
            if (leave != null)
            {
                context.LeaveDays.Remove(leave);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditLeaveAsync(Guid employeeId, LeaveDayDto leave)
        {
            var employee = await context.Employees.Include(e => e.Leaves).FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null) throw new Exception("Employee not found");
            if (employee.Leaves == null) throw new Exception("Leave entry not found");

            var existing = employee.Leaves.FirstOrDefault(ld => ld.Id == leave.Id);
            if (existing == null) throw new Exception("Leave entry not found");

            if (employee.Leaves.Any(ld => ld.EmployeeId != employeeId && leave.StartDate <= ld.EndDate && leave.EndDate >= ld.StartDate))
                throw new Exception("Leave dates overlap with existing leave");

            existing.StartDate = leave.StartDate;
            existing.EndDate = leave.EndDate;
            await context.SaveChangesAsync();
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync()
        {
            var query = context.Employees.Include(e => e.Leaves).AsQueryable();            

            return await query.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                TotalLeaveDays = e.TotalLeaveDays,
                Leaves = e.Leaves.Select(ld => new LeaveDayDto
                {
                    Id = ld.Id,
                    StartDate = ld.StartDate,
                    EndDate = ld.EndDate
                }).ToList()
            }).ToListAsync();
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync(string? nameFilter)
        {
            var query = context.Employees.Include(e => e.Leaves).AsQueryable();

            if (!string.IsNullOrWhiteSpace(nameFilter))
                query = query.Where(e => e.Name.Contains(nameFilter));

            return await query.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                TotalLeaveDays = e.TotalLeaveDays,
                Leaves = e.Leaves.Select(ld => new LeaveDayDto
                {
                    Id = ld.Id,
                    StartDate = ld.StartDate,
                    EndDate = ld.EndDate
                }).ToList()
            }).ToListAsync();
        }


        public async Task<EmployeeDto> GetEmployeesById(Guid employeeId)
        {
            var employee = await context.Employees.Include(e => e.Leaves).FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null) throw new Exception("Employee not found");
            return MapToDto(employee);
        }

        private static bool IsOverlapping(CreateLeaveDto newLeave, LeaveDay existing) => 
           newLeave.StartDate <= existing.EndDate && newLeave.EndDate >= existing.StartDate;

        private static EmployeeDto MapToDto(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                TotalLeaveDays = employee.TotalLeaveDays,
                Leaves = employee.Leaves?.Select(ld => new LeaveDayDto
                {
                    Id = ld.Id,
                    StartDate = ld.StartDate,
                    EndDate = ld.EndDate
                }).ToList() ?? new()
            };
        }
    }
}