using EmployeeManagement.Auth.JWT;
using EmployeeManagement.Shared.Models;
using EmployeeManagement.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenGenerator _jwt;
        private readonly PasswordHasher<User> _hasher;

        public AuthService(AppDbContext context, JwtTokenGenerator jwt)
        {
            _context = context;
            _jwt = jwt;
            _hasher = new PasswordHasher<User>();
        }

        public string? Authenticate(User user)
        {
            var userFromDb = _context.Users.FirstOrDefault(u => u.Username == user.Username);

            if (userFromDb == null)
                return null;

            var result = _hasher.VerifyHashedPassword(userFromDb, userFromDb.Password, user.Password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            return _jwt.GenerateToken(user.Username);
        }
    }
}
