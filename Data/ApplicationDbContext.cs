using ASPNetCoreIdentityCustomFields.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly2.Models;

namespace Vidly2.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<MembershipType> MembershipType { get; set; }

		}
}