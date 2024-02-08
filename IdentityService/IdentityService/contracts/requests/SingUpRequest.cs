namespace IdentityService.Contracts.Requests
{
    public class SingUpRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
