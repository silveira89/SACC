using Microsoft.AspNetCore.Mvc;

namespace SACC.Controllers {

    [Controller]
    public class HomeController : Controller {

        [HttpGet("")]
        public IActionResult Index() {
            return View();
        }
    }
}
