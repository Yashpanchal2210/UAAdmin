using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UAAdmin.Models;
using UAAdmin.Service.Service.CRM;

namespace UAAdmin.Controllers
{
    public class LoginController : Controller
    {
        #region Fields
        private readonly ICRMRepository _cRMRepository;

        [TempData]
        public string AlertMessage { get; set; }
        #endregion

        #region Ctor
        public LoginController(ICRMRepository cRMRepository)
        {
            _cRMRepository = cRMRepository;
        }
        #endregion

        #region Methods
        public IActionResult Login(string ReturnUrl = "")
        {
            LoginViewModel model = new LoginViewModel();
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            if (!string.IsNullOrEmpty(loginViewModel.Username) && !string.IsNullOrEmpty(loginViewModel.Password))
            {
                var result = _cRMRepository.Authenticate(loginViewModel.Username, loginViewModel.Password);

                if (result == true)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.UserData, loginViewModel.Username) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("AdminName", loginViewModel.Username);
                    HttpContext.Session.SetString("isUserLogged", "True");

                    AlertMessage = "You have been successfully logged in";

                    if (!String.IsNullOrEmpty(loginViewModel.ReturnUrl))
                    {
                        return RedirectToAction("Dashboard", "Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Dashboard");
                    }
                }
            }
            loginViewModel.ErrorMessage = "Please enter valid credentials";
            return View(loginViewModel);
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

        #endregion
    }
}
