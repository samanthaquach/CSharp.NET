using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Models
{
    public class BankContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Account { get; set; }

    }
}