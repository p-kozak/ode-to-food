using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Text;

namespace OdeToFood.Data
{
	//EntityFramework stores and manages data using information from DbContext
	public class OdeToFoodDbContext : DbContext //DbContext to work with entityframework
	{
		public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
			:base(options)//forwading to the base class
		{

		}
		public DbSet<Restaurant> Restaurants { get; set; } //Property of type Restaurant that will be stored in the database

	}
}
