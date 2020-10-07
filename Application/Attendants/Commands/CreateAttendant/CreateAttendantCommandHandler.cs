using Domain.Attendants;
using Domain.BaseIdentities;
using Domain.Speakers;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attendants.Commands.CreateAttendant
{
    public class CreateAttendantCommandHandler : IRequestHandler<CreateAttendantCommand>
    {
        private readonly FIADbContext Context;

        public CreateAttendantCommandHandler(FIADbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(CreateAttendantCommand request, CancellationToken cancellationToken)
        {
            var attendant = new Attendant(request.FullName, request.Email, request.PhoneNumber, IdentityRole.Attendant)
            {
            };

            Context.Attendants.Add(attendant);
            await Context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
