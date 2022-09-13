using SACC.Data;
using SACC.Models;
using SACC.Repositories.Interfaces;

namespace SACC.Repositories {
    public class UserRepository : IUserRepository {

        private readonly Contents _content;

        public UserRepository(Contents content) {
            _content = content;
        }

        public IEnumerable<User> Users => _content.Users;

        public User GetUserId(string userId) {
            return _content.Users.FirstOrDefault(b => b.Id == userId);
        }

    }
}
