using ReviewService.Contracts.Requests;
using ReviewService.Models;
using ReviewService.Repository;

namespace ReviewService.Endpoints
{
    public class AddReviewEndpoint : Endpoint<AddReviewRequest>
    {
        private readonly IReviewRepository _repo;

        public AddReviewEndpoint(IReviewRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("review");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddReviewRequest req, CancellationToken ct)
        {
            var review = new Review()
            {
                ReviewId = Guid.NewGuid(),
                Body = req.Body,
                Rating = req.Rating,
                BookId = req.BookId,
            };

            var result = await _repo.AddReview(review);

            if(!result)
            {
                await SendStringAsync("Something went wrong", 400, cancellation: ct);
                return;
            }

            await SendOkAsync(ct);
        }
    }
}
