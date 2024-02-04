﻿namespace BookService.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string Publisher { get; set; } = default!;
    }
}