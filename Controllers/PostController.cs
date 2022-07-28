using Microsoft.AspNetCore.Mvc;
using SACC.Repositories.Interfaces;

namespace SACC.Controllers {
    public class PostController : Controller {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository) {
            _postRepository = postRepository;
        }

        [HttpGet("post")]
        public IActionResult Index() {
            var posts = _postRepository.Posts;
            return View(posts);
        }
    }
}
