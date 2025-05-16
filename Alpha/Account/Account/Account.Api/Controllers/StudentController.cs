using Account.Api.AppDataLayer;
using Account.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _dataContext;

        public StudentController(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Student student)
        {
            await _dataContext.Students.AddAsync(student);
            await _dataContext.SaveChangesAsync();
            return Ok(student.Id);
        }
    }
}