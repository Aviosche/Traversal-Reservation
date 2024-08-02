using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Admin.Models.ViewComponents
{
    public class _DashboardBanner : ViewComponent
    {

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
