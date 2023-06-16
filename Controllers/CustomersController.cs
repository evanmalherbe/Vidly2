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
		
			var viewModel = new CustomerFormViewModel
			{
				MembershipTypes = types,
				Customer = new Customer()
			};

			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{ 
					Customer = customer,
					MembershipTypes = _context.MembershipType.ToList()
				};

				return View("CustomerForm", viewModel);
			}

			if (customer.Id == 0)
			{
				_context.Customers.Add(customer);
			}
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}
		
			_context.SaveChanges();

			return RedirectToAction("CustomerList", "Customers");
		}

		public IActionResult Edit(int id)
		{
			Customer? customer = _context.Customers.SingleOrDefault(c => c.Id == id);
			if (customer == null)
			{
				return NotFound();
			}

			CustomerFormViewModel viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipType.ToList()
			};

			return View("CustomerForm", viewModel);
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
			//var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			//var customerList = new CustomerList
			//{
			//	Customers = customers
			//};

			return View();
		}
	}
}
