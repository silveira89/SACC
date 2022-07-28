using Microsoft.AspNetCore.Mvc;
using SACC.Repositories.Interfaces;

namespace SACC.Controllers {

    [Controller]
    public class UserController : Controller {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public IActionResult Index() {
            var users = _userRepository.Users;
            return View(users);
        }
    }
}
