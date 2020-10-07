using Application.Speakers.Queries.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Speakers.Queries.GetSpeakerDetails
{
    public class GetSepakerDetailsQuery : IRequest<SpeakerVm>
    {
        public int Id { get; set; }
    }
}
