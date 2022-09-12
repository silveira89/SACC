using Microsoft.AspNetCore.Mvc;

namespace SACC.Controllers {
    public class NetworkController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
