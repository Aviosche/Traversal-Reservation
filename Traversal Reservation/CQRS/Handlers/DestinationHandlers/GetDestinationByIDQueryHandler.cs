using DataAccessLayer.Concrete;
using Traversal_Reservation.CQRS.Queries.DestinationQueries;
using Traversal_Reservation.CQRS.Results.DestinationResults;

namespace Traversal_Reservation.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;
        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price,
                Capacity = values.Capacity,
            };
        }


    }
}
