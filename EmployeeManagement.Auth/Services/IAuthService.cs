using EmployeeManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Auth.Services
{
    public interface IAuthService
    {
        string? Authenticate(User user);
    }
}
