using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class Ticket
{
    [Required] public int Id { get; set; }
    [Required] public Showtime Showtime { get; set; }
    [Required] public Seat Seat { get; set; }

    public Ticket()
    {
    }

    public Ticket(Showtime showtime, Seat seat)
    {
        Showtime = showtime;
        Seat = seat;
    }
}