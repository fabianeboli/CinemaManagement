using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class Film
{
   [Key] public int Id { get; set; }
   [Required] public string Title { get; set; }
   [Required] public string Description { get; set; }
   [Required] public string Genre { get; set; }
   [Required] public int Duration { get; set; }

   public Film()
   {
   }

   public Film(string title, string description, string genre, int duration)
   {
      Title = title;
      Description = description;
      Genre = genre;
      Duration = duration;
   }
}