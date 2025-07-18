using EmployeeManagement.Models;
using System.Threading.Tasks;


namespace EmployeeManagement.Services
{
    public interface IAuthService
    {
        Task<bool> Login(UserLogin userLogin);
        Task Logout();
    }
}
