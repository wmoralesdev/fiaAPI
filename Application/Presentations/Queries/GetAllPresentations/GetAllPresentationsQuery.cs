using Application.Presentations.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Presentations.Queries.GetAllPresentations
{
    public class GetAllPresentationsQuery : IRequest<PresentationListVm>
    {
    }

    public class GetAllPresentationsHandler : IRequestHandler<GetAllPresentationsQuery, PresentationListVm>
    {
        public IFIADbContext context;
        public IMapper mapper;

        public GetAllPresentationsHandler(IFIADbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PresentationListVm> Handle(GetAllPresentationsQuery request, CancellationToken cancellationToken)
        {
            var presentations = await context.Presentations
                .ProjectTo<PresentationVm>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new PresentationListVm(presentations);
        }
    }
}
