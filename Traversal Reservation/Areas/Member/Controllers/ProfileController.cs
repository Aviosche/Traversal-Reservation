using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Reservation.Areas.Member.Models;

namespace Traversal_Reservation.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]")]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel userEditViewModel = new UserEditViewModel();
			userEditViewModel.Name = values.Name;
			userEditViewModel.Surname = values.Surname;
			userEditViewModel.PhoneNumber = values.PhoneNumber;
			userEditViewModel.Mail = values.Email;
			return View(userEditViewModel);
		}
		/*
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
		{
			var user = await _userManager.FindByNameAsync(user.Identity.Name);
			if (userEditViewModel.Image != null)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(userEditViewModel.Image.FileName);
				var imagename = Guid.NewGuid() + extension;
				var savelocation = resource + "/wwwroot/userimages/" + imagename;
				var stream = new FileStream(savelocation, FileMode.Create);
				await userEditViewModel.Image.CopyToAsync(stream);
				user.ImageUrl = imagename;
			}
			user.Name = userEditViewModel.Name;
			user.Surname = userEditViewModel.Surname;
			user.PhoneNumber = userEditViewModel.PhoneNumber;
			user.Mail = userEditViewModel.Mail;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
		*/


	}
}
