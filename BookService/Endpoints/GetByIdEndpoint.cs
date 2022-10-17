using BookService.Contracts.Requests;
using BookService.Contracts.Responses;
using BookService.Data;
using BookService.Repository;
using FastEndpoints;

namespace BookService.Endpoints
{
    public class GetByIdEndpoint : Endpoint<GetByIdRequest>
    {
        private readonly IBookRepository _repo;

        public GetByIdEndpoint(IBookRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("book/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetByIdRequest req, CancellationToken ct)
        {
            var book = await _repo.GetBook(req.Id);

            if (book is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(book, ct);
        }
    }
}
