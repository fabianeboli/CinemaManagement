using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models;

public class Seat
{
    [Key] public int SeatNumber { get; set; }

    [Required, StringLength(1), RegularExpression("[A-Z]", ErrorMessage = "Only A-Z is allowed")]
    public string Row { get; set; } // A-Z

    [Required, MinLength(1), MaxLength(2), RegularExpression("\\d{1,2}", ErrorMessage = "Only 1-99 is allowed")]
    public string Column { get; set; } // 1-99

    public DateTimeOffset ReservedAt { get; set; }

    [ForeignKey("Auditorium")] public int AuditoriumId { get; set; }
    [ForeignKey("User")] public int? ReservedByUserId { get; set; } = null; 
    

    public Seat()
    {
    }

    public Seat(int seatNumber, string row, string column, int auditoriumId, int? reservedByUserId)
    {
        SeatNumber = seatNumber;
        Row = row;
        Column = column;
        AuditoriumId = auditoriumId;
        ReservedByUserId = reservedByUserId;
        ReservedAt = DateTimeOffset.Now;
    }
}