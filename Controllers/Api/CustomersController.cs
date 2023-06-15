using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vidly2.Data;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private ApplicationDbContext _context;

		public CustomersController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET /api/customers
		public IActionResult GetCustomers()
		{
			return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>));
		}

		// GET /api/customers/1
		[HttpGet("{id}")]
		public IActionResult GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
			{
				return NotFound();
			}

			return Ok(Mapper.Map<Customer, CustomerDto>(customer));
		}

		// POST /api/customers
		[HttpPost]
		public IActionResult CreateCustomer(CustomerDto customerDto)
		{
			if(!ModelState.IsValid)
				return BadRequest();

			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.Id = customer.Id;

			return Created(new Uri(Request.GetDisplayUrl() + "/" + customer.Id), customerDto);
		}

		// PUT /api/customers/1
		[HttpPut("{id}")]
		public void UpdateCustomer(int id, CustomerDto customerDto)
		{
			if(!ModelState.IsValid)
				throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

			//Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
			Mapper.Map(customerDto, customerInDb);
			_context.SaveChanges();
				
		}

		// DELETE /api/customers/1
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();	
		
		}
	}
}
