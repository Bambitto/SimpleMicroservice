namespace BookService.Dtos
{
    public class BookPublishDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Event { get; set; } = default!;
    }
}
