using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Traversal_Reservation.Models;

namespace Traversal_Reservation.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel userRegister)
        {
            string password = userRegister.Password;
            AppUser appUser = new AppUser()
            {
                Name = userRegister.Name,
                Surname = userRegister.Surname,
                Email = userRegister.Mail,
                UserName = userRegister.Username
            };
            if(userRegister.Password == userRegister.ConfirmPassword)
            {
				var result = await _userManager.CreateAsync(appUser, password);
				if (result.Succeeded)
					return RedirectToAction("SignIn");
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
            }
            return View(userRegister);
        }
        

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel userSignIn)
        {
            if(ModelState.IsValid)
            {
                
                var user = await _userManager.FindByNameAsync(userSignIn.Username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userSignIn.Password, false, true);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Profile", new { area = "Member" });
                    else
                        return RedirectToAction("SignIn", "Login");
                }
                
                
            }
            return View();
        }


    }
}
