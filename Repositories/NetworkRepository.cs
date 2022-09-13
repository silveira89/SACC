using SACC.Data;
using SACC.Models;
using SACC.Repositories.Interfaces;

namespace SACC.Repositories {
    public class NetworkRepository : INetworkRepository {

        private readonly Contents _content;

        public NetworkRepository(Contents content) {
            _content = content;
        }

        public User GetUserName(string name) {
            var user = _content.Users.FirstOrDefault(x => x.UserName == name);
            return user;
        }
    }
}
