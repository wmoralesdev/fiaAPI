using Application.Speakers.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Speakers.Queries.GetAllSpeakers
{
    public class GetAllSpeakersHandler : IRequestHandler<GetAllSpeakersQuery, SpeakerListVm>
    {
        public IFIADbContext context;
        public IMapper mapper;

        public GetAllSpeakersHandler(IFIADbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SpeakerListVm> Handle(GetAllSpeakersQuery request, CancellationToken cancellationToken)
        {
            var speakers = await context.Speakers
                .ProjectTo<SpeakerVm>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new SpeakerListVm(speakers);
        }
    }
}
