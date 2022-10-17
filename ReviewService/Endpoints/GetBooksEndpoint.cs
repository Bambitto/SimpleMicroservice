using ReviewService.Repository;

namespace ReviewService.Endpoints
{
    public class GetBooksEndpoint : EndpointWithoutRequest
    {
        private readonly IReviewRepository _repo;

        public GetBooksEndpoint(IReviewRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("review/books");
            AllowAnonymous();
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            var books = await _repo.GetAllBooks();
            await SendOkAsync(books, ct);
        }
    }
}
