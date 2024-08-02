using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Member.Models.ViewComponents.Dashboard
{
    public class _PlatformSetting : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
