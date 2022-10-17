namespace ReviewService.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public Guid ExternalId { get; set; }
        public IEnumerable<Review> Reviews { get; set; } = default!;
    }
}
