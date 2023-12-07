using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class Auditorium
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public Theater Theater { get; set; }
    [Required] public List<Seat> Seats { get; set; }

    public Auditorium()
    {
    }

    public Auditorium(string name, Theater theater, List<Seat> seats)
    {
        Name = name;
        Theater = theater;
        Seats = seats;
    }
}