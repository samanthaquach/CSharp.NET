using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Wedding_Planner.Models
{
    public class WeddingContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Planning> planning { get; set; }
        public DbSet<RSVP> RSVP { get; set; }

    }
}