using EmployeeManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Infrastructure.DbContext;
using EmployeeManagement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Application.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly AppDbContext _context; 

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return await _context.Employees.Select(e=>new EmployeeDto
            {
                Id=e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                Position = e.Position,
                Salary = e.Salary
            }).ToListAsync();
        }
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var e = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (e == null) return null;

            return new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                Position = e.Position,
                Salary = e.Salary
            };
        }
        public async Task<EmployeeDto> CreateAsync(EmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Position = dto.Position,
                Salary = dto.Salary
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            //dto.Id = employee.Id;
            //return dto;

            return new EmployeeDto     
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position,
                Salary = employee.Salary
            };

        }
        public async Task<EmployeeDto?> UpdateAsync(int id, EmployeeDto dto)
        {
            var e = await _context.Employees.FindAsync(id);
            if (e == null) return null;

            e.FirstName = dto.FirstName;
            e.LastName = dto.LastName;
            e.Email = dto.Email;
            e.DateOfBirth = dto.DateOfBirth;
            e.Position = dto.Position;
            e.Salary = dto.Salary;

            await _context.SaveChangesAsync();

            return new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                Position = e.Position,
                Salary = e.Salary
            };

        }
        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _context.Employees.FindAsync(id);
            if (e == null) return false;

            _context.Employees.Remove(e);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
