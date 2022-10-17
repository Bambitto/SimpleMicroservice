using ReviewService.Contracts.Requests;
using ReviewService.Contracts.Responses;
using ReviewService.Repository;

namespace ReviewService.Endpoints
{
    public class GetReviewsForBookEndpoint : Endpoint<GetReviewsForBookRequest, ReviewsResponse>
    {
        private readonly IReviewRepository _repo;

        public GetReviewsForBookEndpoint(IReviewRepository repo)
        {
            _repo = repo;
        }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("review");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetReviewsForBookRequest req, CancellationToken ct)
        {
            var reviews = await _repo.GetReviewsForBook(req.BookId);

            var response = new ReviewsResponse()
            {
                Reviews = reviews.Select(x => new ReviewResponse
                {
                    Rating = x.Rating,
                    Body = x.Body,
                })
            };

            await SendOkAsync(response, ct);
        }
    }
}
