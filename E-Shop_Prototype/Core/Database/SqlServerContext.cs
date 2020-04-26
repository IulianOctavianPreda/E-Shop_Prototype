using System.Reflection;
using E_Shop_Mini.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Database
{
    public class SqlServerContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Category> Category { get; set; }


        public SqlServerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // the name of one of anything from the project that hosts the mappings/configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
