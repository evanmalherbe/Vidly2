using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
  public class Movie
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Release date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
     [Display(Name = "Date Added")]
    public DateTime DateAdded { get; set; }

    [Required]
    [Display(Name = "Number in Stock")]
    public byte NumberInStock { get; set; }

    [Required]
    [Display(Name = "Genre")]
    public int GenreId { get; set; }

    public Genre Genre { get; set; }
  }
    
}
