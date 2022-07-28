using SACC.Models;

namespace SACC.Repositories.Interfaces {
    public interface IUserRepository {
        IEnumerable<User> Users { get; }

        User GetUserId(string userId);
    }
}
