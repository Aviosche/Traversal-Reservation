using MediatR;
using Traversal_Reservation.CQRS.Results.GuideResults;

namespace Traversal_Reservation.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
