using Domain.Speakers;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Speakers.Commands.UpdateSpeaker
{
    public class UpdateSpeakerCommandHandler : IRequestHandler<UpdateSpeakerCommand>
    {
        private readonly FIADbContext Context;

        public UpdateSpeakerCommandHandler(FIADbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(UpdateSpeakerCommand request, CancellationToken cancellationToken)
        {
            var speaker = await Context.Speakers.FindAsync(request.Email);

            speaker.Email = request.Email ?? speaker.Email;
            speaker.FullName = request.FullName ?? speaker.FullName;
            speaker.PhoneNumber = request.PhoneNumber ?? speaker.PhoneNumber;

            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
