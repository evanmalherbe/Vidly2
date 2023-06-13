using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly2.Data;
using Vidly2.Models;

namespace Vidly2.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController(ApplicationDbContext context)
		{
			_context = context;
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// customers/details/{id}
		public IActionResult Details(int id)
	 {
		var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
				
		//		new List<Customer>
		//{
		//	new Customer { Name = "Jane Smith"},
		//	new Customer { Name = "Bob Hope"}
		//};

		if (customer == null)
		{
			return NotFound();
		}
		
		 return View(customer);
	 }

		public IActionResult CustomerList()
		{
			var customers = _context.Customers.Include(c => c.MembershipType).ToList();
			//var customers = new List<Customer>
			//{
			//	new Customer { Name = "Jane Smith"},
			//	new Customer { Name = "Bob Hope"}
			//};

			var customerList = new CustomerList
			{
				Customers = customers
			};

			return View(customerList);
		}
	}
}
