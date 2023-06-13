using Vidly2.Models;

namespace Vidly2.ViewModels
{
	public class NewCustomerViewModel
	{
		public IEnumerable<MembershipType> MembershipTypes { get; set; }
		public Customer Customer { get; set; }
	}
}
