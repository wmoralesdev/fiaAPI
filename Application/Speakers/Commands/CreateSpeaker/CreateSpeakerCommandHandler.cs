using Domain.BaseIdentities;
using Domain.Speakers;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Speakers.Commands
{
    public class CreateSpeakerCommandHandler : IRequestHandler<CreateSpeakerCommand>
    {
        private readonly FIADbContext Context;

        public CreateSpeakerCommandHandler(FIADbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(CreateSpeakerCommand request, CancellationToken cancellationToken)
        {
            var speaker = new Speaker(request.FullName, request.Email, request.PhoneNumber, IdentityRole.Speaker)
            {
            };

            Context.Speakers.Add(speaker);
            await Context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
