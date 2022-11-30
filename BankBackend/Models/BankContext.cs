using Microsoft.EntityFrameworkCore;

namespace BankBackend.Models
{
    public class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // path of database file
            options.UseSqlite("Data Source=Bank.db");
        }
    }
}
