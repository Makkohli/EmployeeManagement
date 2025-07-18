using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(EmployeeDto employee);
        Task<bool> UpdateAsync(EmployeeDto employee);
        Task<bool> DeleteAsync(int id);
    }
}
