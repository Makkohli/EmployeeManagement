using EmployeeManagement.Infrastructure.Entities;
using EmployeeManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
        
    }
}
