using ReviewService.Models;

namespace ReviewService.Contracts.Responses
{
    public class ReviewsResponse
    {
        public IEnumerable<ReviewResponse> Reviews { get; set; } = default!;
    }
}
