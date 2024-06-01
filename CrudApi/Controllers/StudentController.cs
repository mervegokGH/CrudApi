using CrudApi._DbContext;
using CrudApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDb;
        public StudentController(StudentDbContext studentDb)
        {
            _studentDb = studentDb;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            if (_studentDb.Students==null)
            {
                return BadRequest("We do not have a students");
            }
            else {

                return await _studentDb.Students.ToListAsync();

            }
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Student>>> CreateStudent(Student student)
        {
            _studentDb.Students.Add(student);
            await _studentDb.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentById(int id)
        {
            if (_studentDb.Students==null)
            {
                return BadRequest("We do not have a students");
            }
            var student = await _studentDb.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Student>>> DeleteStudent(int id)
        {
            var student = await _studentDb.Students.FindAsync(id);
            if (_studentDb.Students == null)
            {
                return NotFound();
            }
            _studentDb.Students.Remove(student);
            await _studentDb.SaveChangesAsync();
            return Ok(student);
        }

    }
}
