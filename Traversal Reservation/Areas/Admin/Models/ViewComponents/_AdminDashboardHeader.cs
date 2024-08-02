using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Admin.Models.ViewComponents
{
    public class _AdminDashboardHeader : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
