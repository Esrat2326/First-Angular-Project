using FullStack_API.Data;
using FullStack_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;

        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

       

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
           var employee= await _fullStackDbContext.employees.ToListAsync();
            return Ok(employee);
        }

        [HttpPost]  

        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            employee.Id =Guid.NewGuid();
            await _fullStackDbContext.employees.AddAsync(employee);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employee); 
        }
    }
}
