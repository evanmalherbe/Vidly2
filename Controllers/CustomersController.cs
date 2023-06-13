using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly2.Data;
using Vidly2.Models;
using Vidly2.ViewModels;

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

		public IActionResult New()
		{
			var types = _context.MembershipType.ToList();
		
			var viewModel = new NewCustomerViewModel
			{
				MembershipTypes = types
			};

			return View(viewModel);
		}

		// customers/details/{id}
		public IActionResult Details(int id)
	 {
		var customer = _context.Customers
				.Include(c => c.MembershipType)
				.SingleOrDefault(c => c.Id == id);

		if (customer == null)
		{
			return NotFound();
		}
		
		 return View(customer);
	 }

		public IActionResult CustomerList()
		{
			var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			var customerList = new CustomerList
			{
				Customers = customers
			};

			return View(customerList);
		}
	}
}
