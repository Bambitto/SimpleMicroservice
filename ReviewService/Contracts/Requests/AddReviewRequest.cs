using ReviewService.Models;

namespace ReviewService.Contracts.Requests
{
    public class AddReviewRequest
    {
        public string Body { get; set; } = default!;
        public int Rating { get; set; } = default!;
        public Guid BookId { get; set; }
    }
}
