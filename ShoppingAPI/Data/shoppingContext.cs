using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Models;

namespace ShoppingAPI.Data
{
    public class shoppingContext : DbContext
    {
        public shoppingContext(DbContextOptions<shoppingContext> options) : base(options)

            {

            }

         public DbSet<shoppingItem> shoppingItems { get; set; }
         public DbSet<productItem> productItems { get; set; }
    }
}
