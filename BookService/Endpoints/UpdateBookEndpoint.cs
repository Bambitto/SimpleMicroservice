using BookService.Contracts.Requests;
using BookService.Repository;

namespace BookService.Endpoints
{
    public class UpdateBookEndpoint : Endpoint<UpdateRequest>
    {
        private readonly IBookRepository _repo;

        public UpdateBookEndpoint(IBookRepository repo)
        {
            _repo = repo;
        }
        public override void Configure()
        {
            Verbs(Http.PUT);
            Routes("book");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateRequest req, CancellationToken ct)
        {
            var oldBook = await _repo.GetBook(req.Id);
            if(oldBook is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var result = await _repo.UpdateBook(req, oldBook);

            if (!result)
            {
                await SendStringAsync("Something went wrond", 400, cancellation: ct);
                return;
            }

            await SendOkAsync(ct);
        }
    }
}
