using AutoMapper;
using Domain.Inscriptions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Inscriptions.Commands.CreateInscription
{
    public class CreateInscriptionHandler : IRequestHandler<CreateInscriptionCommand>
    {
        private IFIADbContext context;
        private IMapper mapper;

        public CreateInscriptionHandler(IFIADbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(CreateInscriptionCommand request, CancellationToken cancellationToken)
        {
            var attendant = await context.Attendants
                .Where(a => a.Email == request.Email)
                .FirstOrDefaultAsync();

            var inscription = new Inscription
            {
                PresentationId = request.PresentationId,
                Date = DateTime.Now,
                AttendantId = attendant.Id
            };

            context.Inscriptions.Add(inscription);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
