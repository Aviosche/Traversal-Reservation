using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation.Areas.Member.Controllers
{
    [Area("Member")]
    public class LastDestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public LastDestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetLastDestinations();
            return View(values);
        }
    }
}
