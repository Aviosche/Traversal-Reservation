using Microsoft.AspNetCore.Mvc;
using Traversal_Reservation.CQRS.Commands.DestinationCommands;
using Traversal_Reservation.CQRS.Handlers.DestinationHandlers;
using Traversal_Reservation.CQRS.Queries.DestinationQueries;

namespace Traversal_Reservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [Route("{id}")]
        public IActionResult UpdateDestination(int id) 
        {
            try
            {
                var values = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));
                return View(values);
            }
            catch (Exception)
            {


            }
            return View();
            
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult UpdateDestination(UpdateDestinationCommand command)
        {
            try
            {
                _updateDestinationCommandHandler.Handle(command);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

            }
            return View();

        }

        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [Route("{id}")]
        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }

        



    }
}
