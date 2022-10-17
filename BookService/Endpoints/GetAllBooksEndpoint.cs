using BookService.Contracts.Responses;
using BookService.Repository;
using FastEndpoints;

namespace BookService.Endpoints
{
    public class GetAllBooksEndpoint : EndpointWithoutRequest<EnumBookResponse>
    {
        private readonly IBookRepository _repo;

        public GetAllBooksEndpoint(IBookRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("books");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var books = await _repo.GetAllBooks();

            var response = new EnumBookResponse()
            {
                Books = books.Select(x => new Models.Book
                {
                    Id = x.Id,
                    Author = x.Author,
                    Title = x.Title,
                    Description = x.Description
                })
            };

            await SendOkAsync(response, ct);
        }
    }
}
