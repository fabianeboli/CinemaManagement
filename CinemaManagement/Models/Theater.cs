using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class Theater
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public List<Auditorium> Auditoria { get; set; }

    public Theater()
    {
    }

    public Theater(string name, List<Auditorium> auditoria)
    {
        Name = name;
        Auditoria = auditoria;
    }
}