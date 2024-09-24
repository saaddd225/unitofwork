using System.Data.Entity;
using uniofwork.Models;  // Make sure you have a Models namespace where your entities are defined

namespace uniofwork.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor that points to the connection string
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        // DbSet properties for your entities (tables in your database)
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
// when u create instance of applicationdbcontext using context, it creates a connection to the db, using the connection string defaultconnection. base is context. 