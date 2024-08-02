using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
