using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class User
{
    [Key] public int Id { get; set; }
    [Required, MinLength(3), MaxLength(120), EmailAddress] public string Email { get; set; }
    [Required, MinLength(6)] public string Password { get; set; }
    public string Bookings { get; set; }

    public User()
    {
    }

    public User(string email, string password, string bookings)
    {
        Email = email;
        Password = password;
        Bookings = bookings;
    }
}