using SACC.Models;

namespace SACC.Repositories.Interfaces {
    public interface INetworkRepository {

        User GetUserName(string name);
    }
}
