using SACC.Models;

namespace SACC.Repositories.Interfaces {
    public interface IPostRepository {
        IEnumerable<Post> Posts { get; }

        Post GetPostId(int postId);
    }
}
