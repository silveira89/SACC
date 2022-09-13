using Microsoft.AspNetCore.Mvc;
using SACC.Repositories.Interfaces;

namespace SACC.Controllers {
    public class NetworkController : Controller {

        private readonly INetworkRepository _networkRepository;

        public NetworkController(INetworkRepository networkRepository) {
            _networkRepository = networkRepository;
        }

        public IActionResult Index() {
            var name = User.Identity.Name;
            var user = _networkRepository.GetUserName(name);
            return View(user);
        }
    }
}
