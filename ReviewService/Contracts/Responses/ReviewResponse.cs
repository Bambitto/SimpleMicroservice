namespace ReviewService.Contracts.Responses
{
    public class ReviewResponse
    {
        public string Body { get; set; } = default!;
        public int Rating { get; set; }
    }
}
