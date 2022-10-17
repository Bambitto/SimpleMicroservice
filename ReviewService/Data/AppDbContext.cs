using Microsoft.EntityFrameworkCore;
using ReviewService.Models;

namespace ReviewService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Book> Books => Set<Book>();
    }
}
