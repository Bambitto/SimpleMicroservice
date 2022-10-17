using BookService.Models;

namespace BookService.Contracts.Responses
{
    public class EnumBookResponse
    {
        public IEnumerable<Book> Books { get; set; } = default!;
    }
}
