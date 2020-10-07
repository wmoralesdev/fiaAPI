using Application.Speakers.Queries.Common;
using MediatR;
using System.Collections.Generic;
using System.Text;

namespace Application.Speakers.Queries.GetAllSpeakers
{
    public class GetAllSpeakersQuery : IRequest<SpeakerListVm>
    {
    }
}
