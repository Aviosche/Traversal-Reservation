using MediatR;
using Traversal_Reservation.CQRS.Results.GuideResults;

namespace Traversal_Reservation.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
