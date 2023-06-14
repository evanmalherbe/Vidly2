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
		//[HttpPost]
		//public Customer CreateCustomer(Customer customer)
		//{
			
		//}
	}
}
