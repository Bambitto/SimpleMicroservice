using BookService.AsyncDataServices;
using BookService.Contracts.Requests;
using BookService.Dtos;
using BookService.Models;
using BookService.Repository;

namespace BookService.Endpoints
{
    public class AddBookEndpoint : Endpoint<AddRequest>
    {
        private readonly IBookRepository _repo;
        private readonly IMessageBusClient _messageBusClient;

        public AddBookEndpoint(IBookRepository repo, IMessageBusClient messageBusClient)
        {
            _repo = repo;
            _messageBusClient = messageBusClient;
        }
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("book");
            AllowAnonymous();
        }

        public override async Task HandleAsync(AddRequest req, CancellationToken ct)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = req.Title,
                Author = req.Author,
                Description = req.Description,
                Gender = req.Gender,
                Publisher = req.Publisher,            
            };

            var result = await _repo.AddBook(book);

            if(!result)
            {
                await SendStringAsync("Something went wrond", 400, cancellation: ct);
                return;
            }
            try
            {
                var bookPublishDto = new BookPublishDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Event = "Book_Published"
                };

                _messageBusClient.PublishBook(bookPublishDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"-->Could not send asynchronously: {ex.Message}");
            }

            await SendOkAsync(ct);
        }
    }
}
