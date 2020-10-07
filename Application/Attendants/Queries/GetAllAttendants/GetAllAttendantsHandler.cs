using Application.Attendants.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attendants.Queries.GetAllAttendants
{
    public class GetAllAttendantsHandler : IRequestHandler<GetAllAttendantsQuery, AttendantsListVm>
    {
        public IFIADbContext context;
        public IMapper mapper;

        public GetAllAttendantsHandler(IFIADbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AttendantsListVm> Handle(GetAllAttendantsQuery request, CancellationToken cancellationToken)
        {
            var attendants = await context.Attendants
                .ProjectTo<AttendantVm>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new AttendantsListVm(attendants);
        }
    }
}
