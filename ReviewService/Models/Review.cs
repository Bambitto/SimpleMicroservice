namespace ReviewService.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        public string Body { get; set; } = default!;
        public int Rating { get; set; } = default!;
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
    }
}
