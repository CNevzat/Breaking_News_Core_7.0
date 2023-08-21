using BreakingNews_Core7._0.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BreakingNews_Core7._0.Utility
{
	public class ApplicationDBContext : IdentityDbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
		}
		public DbSet<News> News { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		
	}
}
