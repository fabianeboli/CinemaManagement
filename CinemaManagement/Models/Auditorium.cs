using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models;

public class Auditorium
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required, ForeignKey(nameof(Theater))] public int TheaterId { get; set; }
    public Theater Theater { get; set; }
    [Required] public ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public Auditorium()
    {
    }

    public Auditorium(string name, int theaterId)
    {
        Name = name;
        TheaterId = theaterId;
    }
}