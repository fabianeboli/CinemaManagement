using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models;

public class Ticket
{
    [Key] public int Id { get; set; }
    [Required, ForeignKey("Showtime")] public int ShowtimeId { get; set; }
    [Required, ForeignKey("Seat")] public int SeatId { get; set; }
    public bool IsConfirmed { get; set; }

    public Ticket()
    {

    }

    public Ticket(int showtimeId, int seatId)
    {
        ShowtimeId = showtimeId;
        SeatId = seatId;
    }
}
     
     