using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Speakers.Commands.DeleteSpeaker
{
    public class DeleteSpeakerHandler : IRequestHandler<DeleteSpeakerCommand>
    {
        public IFIADbContext context;

        public DeleteSpeakerHandler(IFIADbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteSpeakerCommand request, CancellationToken cancellationToken)
        {
            var speaker = await context.Speakers
                    .Where(s => s.Id == request.Id)
                    .FirstOrDefaultAsync();

            context.Speakers.Remove(speaker);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
