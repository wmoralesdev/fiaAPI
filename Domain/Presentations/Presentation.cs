using Domain.Inscriptions;
using Domain.Speakers;
using System;
using System.Collections.Generic;

namespace Domain.Presentations
{
    public class Presentation
    {
        public int PresentationId { get; set; }

        public DateTime Schedule { get; set; }

        public int? SpeakerId { get; set; }

        public virtual Speaker Speaker { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Inscription> Inscriptions{ get; private set; }
    }
}
