using System;
using System.Collections.Generic;

namespace Application.Attendants.Queries.Common
{
    public class AttendantsListVm
    {
        public IList<AttendantVm> Attendants { get; set; }

        public int Size => Attendants.Count;

        public AttendantsListVm(IList<AttendantVm> attendants)
        {
            Attendants = attendants ?? throw new ArgumentNullException(nameof(attendants));
        }

    }
}
