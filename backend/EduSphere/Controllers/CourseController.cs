using EduSphere.Data;
using EduSphere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduSphere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        //Get all courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            var courses = await _context.Courses
                .Include(c => c.Instructor)
                .ToListAsync();

            return Ok(courses);
        }

        //Get course by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);

        }

        //Post courses
        //Need authorization, add it later
        [HttpPost]
        public async Task<ActionResult<Course>> Create (Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        //Delete course by id
        //Need authorization, add it later
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
