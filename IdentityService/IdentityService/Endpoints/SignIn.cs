using IdentityService.Contracts.Requests;
using IdentityService.Helpers;
using IdentityService.Repository;
using System.Security.Cryptography;

namespace IdentityService.Endpoints
{
    public class SignIn : Endpoint<SignInRequest>
    {
        private readonly IUserRepository _repo;

        public SignIn(IUserRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("LogIn");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SignInRequest req, CancellationToken ct)
        {
            var user = await _repo.GetUser(req.Email);
            if (user == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            if(PasswordManager.VerifyPassword(req.Password, user.Password, user.Salt))
            {

            }
        }
    }
}
