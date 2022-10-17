using ReviewService.Dtos;
using ReviewService.Models;
using ReviewService.Repository;
using System.Text.Json;

namespace ReviewService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _factory;

        public EventProcessor(IServiceScopeFactory factory)
        {
            _factory = factory;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch(eventType)
            {
                case EventType.BookPublished:
                    AddBook(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string message)
        {
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(message);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (eventType.Event == "Book_Published")
            {
                return EventType.BookPublished;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return EventType.Undefined;
        }

        private async void AddBook(string message)
        {
            using var scope = _factory.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<IReviewRepository>();
            var bookPublishDto = JsonSerializer.Deserialize<BookPublishDto>(message);

            try
            {
                var book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = bookPublishDto!.Title,
                    ExternalId = bookPublishDto.Id
                };

                if (!await repo.BookExist(book.ExternalId))
                {
                    await repo.AddBook(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    enum EventType
    {
        BookPublished,
        Undefined
    }
}
