using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Vidly2.Models;

namespace Vidly2.Dtos
{
	public class MovieDto
	{
			public int Id { get; set; }

			[Required]
			public string Name { get; set; }

			[Required(ErrorMessage = "Release date is required.")]
			public DateTime ReleaseDate { get; set; }

			[Required(ErrorMessage = "Date Added is required.")]
			public DateTime DateAdded { get; set; }

			[Required(ErrorMessage = "Number in Stock field is required.")]
			[Range(1,20, ErrorMessage = "The field Number in Stock must be between 0 to 20")]
			public byte NumberInStock { get; set; }

			[Required(ErrorMessage = "Genre is required.")]
			public int GenreId { get; set; } 
	}
}
