namespace IdentityService.Contracts.Requests
{
    public class SignInRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
