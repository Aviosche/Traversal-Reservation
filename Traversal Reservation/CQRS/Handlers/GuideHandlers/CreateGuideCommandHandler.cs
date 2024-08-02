using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using Traversal_Reservation.CQRS.Commands.GuideCommands;

namespace Traversal_Reservation.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true,
            });
            await _context.SaveChangesAsync();
        }

    }
}
