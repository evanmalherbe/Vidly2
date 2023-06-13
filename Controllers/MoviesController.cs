﻿using Microsoft.AspNetCore.Mvc;
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

			//ViewData["Movie"] = movie;
			//ViewBag.Movie = movie;

			return View(viewModel);
		 // return Content("Hello world!");
		// return new EmptyResult();
	 // return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
		}

		// movies/edit/{id}
		public IActionResult Edit(int id)
		{
			return Content("id=" + id);
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
