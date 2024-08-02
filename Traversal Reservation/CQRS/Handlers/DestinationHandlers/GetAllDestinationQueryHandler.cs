using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Traversal_Reservation.CQRS.Queries.DestinationQueries;
using Traversal_Reservation.CQRS.Results.DestinationResults;

namespace Traversal_Reservation.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                ID = x.DestinationID,
                Capacity = x.Capacity,
                City = x.City,
                DayNight = x.DayNight,
                Price = x.Price,
            }).AsNoTracking().ToList();
            return values;
        }

    }
}
