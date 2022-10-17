using Microsoft.EntityFrameworkCore;
using ReviewService.Data;
using ReviewService.Models;

namespace ReviewService.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBook(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> BookExist(Guid ExternalId)
        {
            return await _context.Books.AnyAsync(x => x.ExternalId == ExternalId);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsForBook(Guid BookId)
        {
            return await _context.Reviews.Where(x => x.BookId == BookId).ToListAsync();
        }
    }
}
