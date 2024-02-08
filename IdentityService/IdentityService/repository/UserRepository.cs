using IdentityService.Models;

namespace IdentityService.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User user, User oldUser)
        {
            throw new NotImplementedException();
        }
    }
}
