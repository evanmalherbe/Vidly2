using Microsoft.AspNetCore.Mvc;
using Vidly2.Models;

namespace Vidly2.Controllers
{
	public class CustomersController : Controller
	{
		// customers/details/{id}
		public IActionResult Details(int id)
	 {
		var customers = new List<Customer>
		{
			new Customer { Name = "Jane Smith"},
			new Customer { Name = "Bob Hope"}
		};

		var customer = customers[id];
		
		 return View(customer);
	 }

		public IActionResult CustomerList()
		{
			var customers = new List<Customer>
			{
				new Customer { Name = "Jane Smith"},
				new Customer { Name = "Bob Hope"}
			};

			var customerList = new CustomerList
			{
				Customers = customers
			};

			return View(customerList);
		}
	}
}
