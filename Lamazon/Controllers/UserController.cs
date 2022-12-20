using Lamazon.Helpers;
using Lamazon.Services.Abstraction;
using Lamazon.ViewModels.Constants;
using Lamazon.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lamazon.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        { 
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserCredentialsViewModel userCredentialsViewModel, string returnUrl)
        {
            try
            {
                var userValidationResult = _userService.ValidateUser(userCredentialsViewModel);

                await AuthHelper.SignInUser(userValidationResult, HttpContext);

                if (string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect("/");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("UserLoginError", ex.Message);
                return View(userCredentialsViewModel);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            try
            {
                var registerResultUserViewModel = _userService.RegisterUser(userViewModel);
                await AuthHelper.SignInUser(registerResultUserViewModel, HttpContext);
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UserRegisterError", ex.Message);
                return View(userViewModel);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await AuthHelper.SignOutUser(HttpContext);
            return Redirect("/");
        }
    }
}
