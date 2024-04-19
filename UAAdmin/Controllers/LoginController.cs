using Microsoft.AspNetCore.Mvc;

namespace UAAdmin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}
