using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class Theater
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public ICollection<Auditorium> Auditoria { get; set; } = new List<Auditorium>();

    public Theater()
    {
    }

    public Theater(string name)
    {
        Name = name;
    }
}