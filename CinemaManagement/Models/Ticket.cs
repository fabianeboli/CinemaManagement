using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models;

public class Ticket
{
    [Key] public int Id { get; set; }
    [Required, ForeignKey("User")] public int UserId { get; set; }

    [Required, ForeignKey("Showtime")] public int ShowtimeId { get; set; }
    [Required, ForeignKey("Seat")] public ICollection<Seat> SeatId { get; set; } = [];
    public bool IsConfirmed { get; set; }
    public decimal TotalPrice { get; set; }

    public Ticket()
    {

    }

    public Ticket(int showtimeId, List<Seat> seats, int totalPrice = 0)
    {
        ShowtimeId = showtimeId;
        SeatId = seats;
        TotalPrice = totalPrice;
    }
}