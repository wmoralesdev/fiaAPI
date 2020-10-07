using Application.Attendants.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Inscriptions.Queries.GetAllAttendants
{
    public class GetAllAttendantsHandler : IRequestHandler<GetAllAttendantsQuery, AttendantsListVm>
    {
        public readonly IFIADbContext context;
        public readonly IMapper mapper;

        public GetAllAttendantsHandler(IFIADbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AttendantsListVm> Handle(GetAllAttendantsQuery request, CancellationToken cancellationToken)
        {            
            var attendants = await context.Presentations
                .Where(p => p.PresentationId == request.Id)
                .SelectMany(p => p.Inscriptions)
                .Select(i => i.Attendant)
                .ProjectTo<AttendantVm>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new AttendantsListVm(attendants);
        }
    }
}
