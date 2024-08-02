using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Member.Controllers
{
	[Area("Member")]
	public class CommentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
