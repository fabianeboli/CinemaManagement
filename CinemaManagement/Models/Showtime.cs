using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class Showtime
{
   [Required] public int Id { get; set; }
   [Required] public Film Film { get; set; }
   [Required] public DateTime Date { get; set; }
   [Required] public Auditorium Auditorium { get; set; }
   public decimal Price { get; set; }

   public Showtime()
   {
   }

   public Showtime(Film film, DateTime date, Auditorium auditorium, decimal price = 0)
   {
      Film = film;
      Date = date;
      Auditorium = auditorium;
   }
}