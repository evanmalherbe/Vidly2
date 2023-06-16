using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
  public class Movie
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required(ErrorMessage = "Release date is required.")]
    [Display(Name = "Release date")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Date Added is required.")]
    [Display(Name = "Date Added")]
    public DateTime DateAdded { get; set; }

    [Required(ErrorMessage = "Number in Stock field is required.")]
    [Range(1,20, ErrorMessage = "The field Number in Stock must be between 0 to 20")]
    [Display(Name = "Number in Stock")]
    public byte NumberInStock { get; set; }

    [Required(ErrorMessage = "Genre is required.")]
    [Display(Name = "Genre")]
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
  }
    
}
