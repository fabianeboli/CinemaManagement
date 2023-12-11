using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models;

public class User
{
    [Key] public int Id { get; set; }
    [Required, MinLength(3), MaxLength(120), EmailAddress] public string Email { get; set; }
    [Required, MinLength(6)] public string Password { get; set; }
    [ForeignKey("TicketId")] public ICollection<Ticket> Tickets { get; set; } = [];

    public User()
    {
    }

    public User(string email, string password, ICollection<Ticket> tickets)
    {
        Email = email;
        Password = password;
        Tickets = tickets;
    }
}