using BookService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<Book> Books => Set<Book>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(x => x.Title).IsRequired();

            modelBuilder.Entity<Book>()
                .Property(x => x.Author).IsRequired();

            modelBuilder.Entity<Book>()
                .Property(x => x.Description).IsRequired().HasMaxLength(200);
        }
    }
}
