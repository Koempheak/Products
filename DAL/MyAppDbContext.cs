using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.DAL
{
	public class MyAppDbContext: DbContext
	{
        internal object products;

        public MyAppDbContext(DbContextOptions options) : base(options) 
		{
			
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set;}
    }
}
