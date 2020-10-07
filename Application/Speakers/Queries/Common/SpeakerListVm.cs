using System;
using System.Collections.Generic;

namespace Application.Speakers.Queries.Common
{
    public class SpeakerListVm
    {
        public IList<SpeakerVm> Speakers { get; set; }

        public int Size => Speakers.Count;

        public SpeakerListVm(IList<SpeakerVm> speakers)
        {
            Speakers = speakers ?? throw new ArgumentNullException(nameof(speakers));
        }

    }
}
