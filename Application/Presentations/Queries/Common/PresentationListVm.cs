using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Presentations.Queries.Common
{
    public class PresentationListVm
    {
        public IList<PresentationVm> Presentations;

        public int Size => Presentations.Count;

        public PresentationListVm(IList<PresentationVm> presentations)
        {
            Presentations = presentations ?? throw new ArgumentNullException(nameof(presentations));
        }

    }
}
