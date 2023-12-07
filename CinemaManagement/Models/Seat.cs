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

    [ForeignKey("AuditoriumId")] public Auditorium Auditorium { get; set; }

    public Seat()
    {
    }

    public Seat(int seatNumber, string row, string column, Auditorium auditorium)
    {
        SeatNumber = seatNumber;
        Row = row;
        Column = column;
        Auditorium = auditorium;
    }
}