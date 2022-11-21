using Microsoft.EntityFrameworkCore;

namespace BankBackend.Models
{
    public class BankContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // path of database file
            options.UseSqlite("Data Source=Bank.db");
        }
    }
}
