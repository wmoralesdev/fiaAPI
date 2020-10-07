using Application.Speakers.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Speakers.Queries.GetSpeakerDetails
{
    public class GetSpeakerDetailsHandler : IRequestHandler<GetSepakerDetailsQuery, SpeakerVm>
    {
        public IFIADbContext context;
        public IMapper mapper;

        public GetSpeakerDetailsHandler(IFIADbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SpeakerVm> Handle(GetSepakerDetailsQuery request, CancellationToken cancellationToken)
        {
            var speaker = await context.Speakers
                .Where(s => s.Id == request.Id)
                .ProjectTo<SpeakerVm>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return speaker;
        }
    }
}
