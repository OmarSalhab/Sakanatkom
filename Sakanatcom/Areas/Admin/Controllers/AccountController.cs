using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sakanatcom.Models;
using Sakanatcom.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sakanatcom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserManager { get; }
        public SignInManager<AppUser> SignInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Username or password incorrect");
                return View(loginViewModel);
            }
            var userDeactivate = UserManager.Users.SingleOrDefault(u => u.UserName.ToUpper() == loginViewModel.Email.ToUpper());
            if (userDeactivate != null && !userDeactivate.IsDelete && userDeactivate.IsActive)

            {
                var Result = await SignInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, isPersistent: loginViewModel.RememberMe, false);
                if (Result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Username or password incorrect");
            }
            else
            {
             
                ModelState.AddModelError("", "This user is not registered. Please register before attempting to log in.");
            }
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            AppUser user = new AppUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                IsActive = true,
                IsDelete = false,
                CreateDate = DateTime.UtcNow
            };
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(registerViewModel.Email))
                {
                    ModelState.AddModelError("", "Please Enter The Email");
                }
                if (string.IsNullOrEmpty(registerViewModel.Password) || string.IsNullOrEmpty(registerViewModel.ConfirmPassword))
                {
                    ModelState.AddModelError("", "Please Enter The Password And Confirm It");
                }
                return View(registerViewModel);
            }
            var userExist = UserManager.Users.SingleOrDefault(u => u.UserName.ToUpper() == user.UserName.ToUpper());


            if (userExist != null && !string.IsNullOrEmpty(userExist.UserName))
            {
                ModelState.AddModelError("", "This user is already exist");
            }

            if (userExist == null)
            {
                var Result = await UserManager.CreateAsync(user, registerViewModel.Password);
                if (Result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            ViewBag.Message = "You do not have permission to access this page.";
            return View();
        }

    }
}
