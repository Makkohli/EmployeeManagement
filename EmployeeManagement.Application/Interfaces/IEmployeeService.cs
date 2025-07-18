using EmployeeManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeDto> CreateAsync( EmployeeDto employeeDto );   
        Task<EmployeeDto?> UpdateAsync( int id, EmployeeDto employeeDto );
        Task<bool> DeleteAsync(int id);
    }
}
