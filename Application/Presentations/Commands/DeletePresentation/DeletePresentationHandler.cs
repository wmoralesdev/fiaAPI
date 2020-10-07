using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Presentations.Commands.DeletePresentation
{
    public class DeletePresentationHandler : IRequestHandler<DeletePresentationCommand>
    {
        public IFIADbContext context;

        public DeletePresentationHandler(IFIADbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeletePresentationCommand request, CancellationToken cancellationToken)
        {
            var presentation = await context.Presentations
                    .Where(s => s.PresentationId == request.Id)
                    .FirstOrDefaultAsync();

            context.Presentations.Remove(presentation);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
