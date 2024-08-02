
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Models.ViewComponents.Default
{
    public class _StatisticsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Guides.Count();
            ViewBag.v3 = "4500";
            
            return View();
        }

    }
}
