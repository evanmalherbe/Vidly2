using System.ComponentModel.DataAnnotations;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
	public class MovieFormViewModel
	{
			public IEnumerable<Genre> Genres { get; set; }
			[Key]
			public int? Id { get; set; }

			[Required]
			public string Name { get; set; }

			[Required(ErrorMessage = "Release date is required.")]
			[Display(Name = "Release date")]
			public DateTime? ReleaseDate { get; set; }

			[Required(ErrorMessage = "Number in Stock field is required.")]
			[Range(1,20, ErrorMessage = "The field Number in Stock must be between 0 to 20")]
			[Display(Name = "Number in Stock")]
			public byte? NumberInStock { get; set; }

			[Required(ErrorMessage = "Genre is required.")]
			[Display(Name = "Genre")]
			public int? GenreId { get; set; }

				public MovieFormViewModel()
				{
					Id = 0;
				}

				public MovieFormViewModel(Movie movie)
				{
					Id = movie.Id;
					Name = movie.Name;
					ReleaseDate = movie.ReleaseDate;
					NumberInStock = movie.NumberInStock;
					GenreId = movie.GenreId;
				}

		}
}
