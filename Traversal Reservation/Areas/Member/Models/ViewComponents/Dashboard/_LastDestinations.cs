using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Member.Models.ViewComponents.Dashboard
{
    public class _LastDestinations : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetLastDestinations();
            return View(values);
        }
    }
}
