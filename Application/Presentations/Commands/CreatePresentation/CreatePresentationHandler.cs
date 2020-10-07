using Domain.Presentations;
using Infrastructure;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Presentations.Commands.CreatePresentation
{
    public class CreatePresentationHandler : IRequestHandler<CreatePresentationCommand>
    {
        public IFIADbContext context;

        public CreatePresentationHandler(IFIADbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(CreatePresentationCommand request, CancellationToken cancellationToken)
        {
            var presentation = new Presentation
            {
                Schedule = request.Schedule,
                SpeakerId = request.SpeakerId,
                Description = request.Description,
                Title = request.Title
            };

            context.Presentations.Add(presentation);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
