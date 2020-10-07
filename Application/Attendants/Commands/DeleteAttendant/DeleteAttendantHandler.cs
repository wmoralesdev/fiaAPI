using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attendants.Commands.DeleteAttendant
{
    public class DeleteAttendantHandler : IRequestHandler<DeleteAttendantCommand>
    {
        public IFIADbContext context;

        public DeleteAttendantHandler(IFIADbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteAttendantCommand request, CancellationToken cancellationToken)
        {
            var attendant = await context.Attendants
                    .Where(s => s.Id == request.Id)
                    .FirstOrDefaultAsync();

            context.Attendants.Remove(attendant);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
