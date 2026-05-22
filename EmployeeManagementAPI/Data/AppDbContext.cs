using Microsoft.EntityFrameworkCore;    
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        //This class is the bridge between our application and the database.
        //It allows us to perform CRUD operations on our Employee entity.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //DbSet<Employee> tells EF to create an Employees table
        public DbSet<Employee> Employees { get; set; }
    }
}
