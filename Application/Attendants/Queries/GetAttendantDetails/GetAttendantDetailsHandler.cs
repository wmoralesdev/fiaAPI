using Application.Attendants.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Attendants.Queries.GetAttendantDetails
{
    public class GetAttendantDetailsHandler : IRequestHandler<GetAttendantDetailsQuery, AttendantVm>
    {
        public IFIADbContext context;
        public IMapper mapper;

        public GetAttendantDetailsHandler(IFIADbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AttendantVm> Handle(GetAttendantDetailsQuery request, CancellationToken cancellationToken)
        {
            var attendant = await context.Attendants
                .Where(a => a.Id == request.Id)
                .ProjectTo<AttendantVm>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return attendant;
        }
    }
}
