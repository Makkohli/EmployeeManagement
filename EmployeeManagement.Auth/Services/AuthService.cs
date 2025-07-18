using EmployeeManagement.Auth.JWT;
using EmployeeManagement.Shared.Models;
using EmployeeManagement.Infrastructure.DbContext;

using System;

namespace EmployeeManagement.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(AppDbContext context, JwtTokenGenerator jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public string? Authenticate(User user)
        {
            var validUser = _context.Users.FirstOrDefault(u =>
                u.Username == user.Username && u.Password == user.Password);

            if (validUser == null)
                return null;

            return _jwt.GenerateToken(user.Username);
        }
    }

}