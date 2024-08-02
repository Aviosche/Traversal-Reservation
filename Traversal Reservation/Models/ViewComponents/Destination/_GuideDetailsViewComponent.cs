using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Models.ViewComponents.Destination
{
    public class _GuideDetailsViewComponent : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _GuideDetailsViewComponent(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideService.TGetByID(1);
            return View(values);
        }


    }
}
