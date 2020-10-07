using Domain.Speakers;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attendants.Commands.UpdateAttendant
{
    public class UpdateAttendantCommandHandler : IRequestHandler<UpdateAttendantCommand>
    {
        private readonly FIADbContext Context;

        public UpdateAttendantCommandHandler(FIADbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(UpdateAttendantCommand request, CancellationToken cancellationToken)
        {
            var attendant = await Context.Attendants.FindAsync(request.Email);

            attendant.Email = request.Email ?? attendant.Email;
            attendant.FullName = request.FullName ?? attendant.FullName;
            attendant.PhoneNumber = request.PhoneNumber ?? attendant.PhoneNumber;

            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
