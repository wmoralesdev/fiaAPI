using Domain.Presentations;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Presentations.Commands.UpdatePresentation
{
    public class UpdatePresentationHandler : IRequestHandler<UpdatePresentationCommand>
    {
        public IFIADbContext context;

        public UpdatePresentationHandler(IFIADbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(UpdatePresentationCommand request, CancellationToken cancellationToken)
        {
            var presentation = await context.Presentations
                .Where(p => p.PresentationId == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            presentation.Description = request.Description ?? presentation.Description;
            presentation.Title = request.Title ?? presentation.Title;
            presentation.SpeakerId = request.SpeakerId ?? presentation.SpeakerId;
            presentation.Schedule = request.Schedule ?? presentation.Schedule;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
