using Application.Presentations.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Inscriptions.Queries.GetAllPresentations
{
    public class GetAllPresentationsHandler : IRequestHandler<GetAllPresentationsQuery, PresentationListVm>
    {
        public readonly IFIADbContext context;
        public readonly IMapper mapper;

        public GetAllPresentationsHandler(IFIADbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PresentationListVm> Handle(GetAllPresentationsQuery request, CancellationToken cancellationToken)
        {
            var presentations = await context.Attendants
                .Where(p => p.Id == request.Id)
                .SelectMany(p => p.Inscriptions)
                .Select(i => i.Presentation)
                .ProjectTo<PresentationVm>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new PresentationListVm(presentations);
        }
    }
}
