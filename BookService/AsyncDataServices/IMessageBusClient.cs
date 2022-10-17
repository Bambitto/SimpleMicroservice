using BookService.Dtos;

namespace BookService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishBook(BookPublishDto bookPublishDto);
    }
}
