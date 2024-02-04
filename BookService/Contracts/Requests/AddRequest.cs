namespace BookService.Contracts.Requests
{
    public class AddRequest
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string Publisher { get; set; } = default!;
    }
}
