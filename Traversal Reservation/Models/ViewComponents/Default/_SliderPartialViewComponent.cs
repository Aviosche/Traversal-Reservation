using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Models.ViewComponents.Default
{
    public class _SliderPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
