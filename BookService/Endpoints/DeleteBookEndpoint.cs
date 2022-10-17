using BookService.Contracts.Requests;
using BookService.Repository;

namespace BookService.Endpoints
{
    public class DeleteBookEndpoint : Endpoint<DeleteRequest>
    {
        private readonly IBookRepository _repo;

        public DeleteBookEndpoint(IBookRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Verbs(Http.DELETE);
            Routes("book/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
        {
            var book = await _repo.GetBook(req.Id);
            if(book is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var result = await _repo.DeleteBook(book);

            if (!result)
            {
                await SendStringAsync("Something went wrond", 400, cancellation: ct);
                return;
            }

            await SendOkAsync(ct);
        }
    }
}
