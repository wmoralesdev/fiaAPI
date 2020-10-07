using Domain.Attendants;
using Domain.Presentations;
using System;

namespace Domain.Inscriptions
{
    public class Inscription
    {
        public int AttendantId { get; set; }
        
        public virtual Attendant Attendant { get; set; }

        public int PresentationId { get; set; }
        
        public virtual Presentation Presentation { get; set; }

        public DateTime Date { get; set; }
    }
}
