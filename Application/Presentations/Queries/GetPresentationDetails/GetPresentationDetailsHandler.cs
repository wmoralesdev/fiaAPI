using Application.Attendants.Queries.Common;
using Application.Presentations.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Presentations.Queries.GetPresentationDetails
{
    public class GetPresentationDetailsHandler : IRequestHandler<GetPresentationDetailsQuery, PresentationVm>
    {
        public IFIADbContext context;
        public IMapper mapper;

        public GetPresentationDetailsHandler(IFIADbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PresentationVm> Handle(GetPresentationDetailsQuery request, CancellationToken cancellationToken)
        {
            var presentation = await context.Presentations
                .Where(a => a.PresentationId == request.Id)
                .ProjectTo<PresentationVm>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return presentation;
        }
    }
}
