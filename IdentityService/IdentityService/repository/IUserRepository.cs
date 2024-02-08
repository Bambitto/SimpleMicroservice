using IdentityService.Models;

namespace IdentityService.Repository
{
    public interface IUserRepository
    {
        public Task<User?> GetUser(string email);
        public Task<bool> AddUser(User user);
        public Task<bool> Update(User user, User oldUser);
    }
}
