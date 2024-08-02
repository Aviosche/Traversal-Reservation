using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Member.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
