using EduSphere.Data;
using EduSphere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduSphere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsControllers : ControllerBase
    {
       private readonly AppDbContext _context;

        public EventsControllers(AppDbContext context)
        {
            _context = context;
        }

        //Get all events with organizers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAll()
        {
            var events = await _context.Events
                .Include(e => e.Organizer)
                .ToListAsync();

            return Ok(events);
        }

        //Get event by Id 
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetById(int id)
        {
            var ev = await _context.Events
            .Include(e => e.Organizer)
            .FirstOrDefaultAsync(e => e.Id == id);

            if(ev == null)
                    return NotFound();

            return Ok(ev);
        }

        //Post event
        [HttpPost]
        public async Task<ActionResult<Event>> Create(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ev.Id }, ev);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Event>> Delete(int id)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (ev == null)
                return NotFound();

            _context.Events.Remove(ev);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DATABASE UPDATE, PASSWORD ADDED

    }
}
