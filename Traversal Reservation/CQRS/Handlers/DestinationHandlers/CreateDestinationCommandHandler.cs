using DataAccessLayer.Concrete;
using Traversal_Reservation.CQRS.Commands.DestinationCommands;

namespace Traversal_Reservation.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new EntityLayer.Concrete.Destination
            {
                City = command.City,
                Price = command.Price,
                Capacity = command.Capacity,
                DayNight = command.DayNight,
                Status = true
            });
            _context.SaveChanges();
        }


    }
}
