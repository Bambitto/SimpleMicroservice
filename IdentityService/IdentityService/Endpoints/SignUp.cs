using IdentityService.Contracts.Requests;
using IdentityService.Helpers;
using IdentityService.Models;
using IdentityService.Repository;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Endpoints
{
    public class SignUp : Endpoint<SingUpRequest>
    {
        private readonly IUserRepository _repo;

        public SignUp(IUserRepository repo)
        {
            _repo = repo;
        }

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("book");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SingUpRequest req, CancellationToken ct)
        {

            var hashedPW = PasswordManager.HashPassword(req.Password, out var salt);
            var user = new User
            {
                Id = new Guid(),
                Email = req.Email,
                Password = req.Password,
                Salt = salt,
                FirstName = req.FirstName,
                LastName = req.LastName,
                LastUpdatedOn = null
            };

            var result = await _repo.AddUser(user);

            if(!result)
            {
                await SendStringAsync("Something went wrong", 400, cancellation: ct);
                return;
            }
        }
    }
}
