using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models; 

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        //DI
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }


        //GET: api/Employee/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(emp);
        }

        //POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);
        }

        //PUT: api/Employee/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee updated)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound("Employee not found");
            }
            emp.Name = updated.Name;
            emp.Department = updated.Department;
            emp.Salary = updated.Salary;
            emp.Email = updated.Email;
            await _context.SaveChangesAsync();
            return Ok(emp);
        }

        //DELETE: api/Employee/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound("Employee not found");
            }
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return Ok("Employee deleted successfully");
        }
    }
}
