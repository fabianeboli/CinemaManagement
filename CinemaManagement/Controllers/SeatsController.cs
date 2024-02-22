using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace CinemaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly CinemaDb _context;

        public SeatsController(CinemaDb context)
        {
            _context = context;
        }

        // GET: api/Seat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
        {
            return await _context.Seats.ToListAsync();
        }

        // GET: api/Seat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(int id)
        {
            var seat = await _context.Seats.FindAsync(id);

            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }

        // PUT: api/Seat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat(int id, Seat seat)
        {
            if (id != seat.Id)
            {
                return BadRequest();
            }

            _context.Entry(seat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> ReserveSeat(int id, int userId)
        {
            var seat = await _context.Seats.FindAsync(id);
            var hasUserReservedSeat = await _context.Seats.FirstOrDefaultAsync(s => s.ReservedByUserId == userId);

            if (hasUserReservedSeat == null) return BadRequest("User has already reserved a seat");
            if (seat == null) return NotFound();
            if (seat.ReservedByUserId != null) return BadRequest("Seat is already reserved");

            seat.ReservedByUserId = userId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("/")]
        public async Task<IActionResult> UnreserveSeatsByTime(DateTimeOffset dateTimeOffset)
        {
            await _context.Seats.ForEachAsync(s =>
                s.ReservedByUserId = s.ReservedAt > dateTimeOffset ? null : s.ReservedByUserId);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Seat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(Seat seat)
        {
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeat), new { id = seat.Id }, seat);
        }

        // DELETE: api/Seat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var seat = await _context.Seats.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool SeatExists(int id)
        {
            return _context.Seats.Any(e => e.Id == id);
        }
    }
}