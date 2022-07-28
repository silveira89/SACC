using SACC.Data;
using SACC.Models;
using SACC.Repositories.Interfaces;

namespace SACC.Repositories {
    public class PostRepository : IPostRepository {

        private readonly Contents _content;

        public PostRepository(Contents content) {
            _content = content;
        }

        public IEnumerable<Post> Posts => _content.Posts;

        public Post GetPostId(int postId) {
            return _content.Posts.FirstOrDefault(b => b.Id == postId);
        }
    }
}
