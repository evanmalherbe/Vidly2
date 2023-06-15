using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vidly2.Data;
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
		public IEnumerable<Customer> GetCustomers()
		{
			return _context.Customers.ToList();
		}

		// GET /api/customers/1
		public Customer GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
			{
				throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
			}

			return customer;
		}

		// POST /api/customers
		[HttpPost]
		public Customer CreateCustomer(Customer customer)
		{
			if(!ModelState.IsValid)
				throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

			_context.Customers.Add(customer);
			_context.SaveChanges();

			return customer;
		}

		// PUT /api/customers/1
		[HttpPut]
		public void UpdateCustomer(int id, Customer customer)
		{
			if(!ModelState.IsValid)
				throw new HttpRequestException(HttpStatusCode.BadRequest.ToString());

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

			customerInDb.Name = customer.Name;
			customerInDb.Birthdate = customer.Birthdate;
			customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			customerInDb.MembershipTypeId = customer.MembershipTypeId;

			_context.SaveChanges();
		}

		// DELETE /api/customers/1
		[HttpDelete]
		public void DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();	
		}
	}
}
