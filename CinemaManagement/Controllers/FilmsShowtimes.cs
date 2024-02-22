using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsShowtimesController : ControllerBase
    {
        private readonly CinemaDb _context;

        public FilmsShowtimesController(CinemaDb context)
        {
            _context = context;
        }

        // GET: api/FilmsShowtimes/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Showtime>> GetShowtimesForFilm(int id)
        {
            var showtime = await _context.Showtimes
                .Where(s => s.Film.Id == id)
                .Include(s => s.Auditorium)
                .ToListAsync();

            if (showtime == null)
            {
                return NotFound();
            }

            return Ok(showtime);
        }
    }
}
