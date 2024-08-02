using DataAccessLayer.Concrete;
using Traversal_Reservation.CQRS.Commands.DestinationCommands;

namespace Traversal_Reservation.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.ID);
            _context.Destinations.Remove(values);
            _context.SaveChanges();
        }



    }
}
