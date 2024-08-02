using DataAccessLayer.Concrete;
using MediatR;
using Traversal_Reservation.CQRS.Queries.GuideQueries;
using Traversal_Reservation.CQRS.Results.GuideResults;

namespace Traversal_Reservation.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.ID);
            return new GetGuideByIDQueryResult
            {
                GuideID = request.ID,
                Description = values.Description,
                Name = values.Name,
            };
        }
    }
}
