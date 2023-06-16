using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Vidly2.Data;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{

		private ApplicationDbContext _context;

		public MoviesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET /api/movies
		public IActionResult GetMovies()
		{
			return Ok(_context.Movies
				.Include(m => m.Genre)
				.ToList()
				.Select(Mapper.Map<Movie, MovieDto>));
		}

		// GET /api/movies/1
		[HttpGet("{id}")]
		public IActionResult GetMovie(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
			{
				return NotFound();
			}

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		// POST /api/movies
		[HttpPost]
		public IActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			_context.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;

			return Created(new Uri(Request.GetDisplayUrl() + "/" + movie.Id), movieDto);
		}

		// PUT /api/movies/1
		[HttpPut("{id}")]
		public void Put(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

			var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);
			
			if (movieInDb == null)
				throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

			Mapper.Map(movieDto, movieInDb);
			_context.SaveChanges();
		}

		// DELETE /api/movies/1
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movieInDb == null)
				throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();
		}
	}
}
