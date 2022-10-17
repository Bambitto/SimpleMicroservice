using ReviewService.Models;

namespace ReviewService.Repository
{
    public interface IReviewRepository
    {
        public Task<IEnumerable<Review>> GetReviewsForBook(Guid BookId);
        public Task<bool> AddReview(Review review);
        public Task<bool> BookExist(Guid ExternalId);
        public Task AddBook(Book book);
        public Task<IEnumerable<Book>> GetAllBooks();
    }
}
