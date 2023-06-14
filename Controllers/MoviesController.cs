using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly2.Data;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController(ApplicationDbContext context)
		{
			_context = context;
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		// GET: Movies/Random
		public IActionResult Random()
		{
			Movie movie = new Movie() { Name = "Shrek"};

			var customers = new List<Customer>
			{
				new Customer {Name = "Customer 1"},
				new Customer { Name = "Customer 2"}
			};
			
			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			return View(viewModel);

		}

		// movies/edit/{id}
		public IActionResult Edit(int id)
		{
			Movie? movie = _context.Movies.SingleOrDefault(c => c.Id == id);
			if (movie == null)
			{
				return NotFound();
			}

			MovieFormViewModel viewModel = new MovieFormViewModel
			{
				Movie = movie,
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		public IActionResult New()
		{
			var genres = _context.Genres.ToList();
		
			var viewModel = new MovieFormViewModel
			{
				Genres = genres,
				Movie = new Movie()
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel
				{ 
					Movie = movie,
					Genres = _context.Genres.ToList()
				};

				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
			{
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.DateAdded = movie.DateAdded;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.NumberInStock = movie.NumberInStock;
				movieInDb.GenreId = movie.GenreId;
			}
			
			_context.SaveChanges();

			return RedirectToAction("MovieList", "Movies");
		}

		public IActionResult MovieList()
		{
			var movies = _context.Movies.Include(c => c.Genre).ToList();

			var list = new MovieList
			{
				Movies = movies
			};

			return View(list);
		}

		public IActionResult Details(int id)
		{
			var customer = _context.Movies
					.Include(c => c.Genre)
					.SingleOrDefault(c => c.Id == id);

			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}
		//movies
		public IActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
			{
				pageIndex = 1;
			}

			if (String.IsNullOrEmpty(sortBy))
			{
				sortBy = "Name";
			}

			return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
		}

		[Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1, 12)}")]
		public IActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}

	}
}
