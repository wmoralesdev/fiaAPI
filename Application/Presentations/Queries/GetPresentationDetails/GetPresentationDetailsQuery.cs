using Application.Attendants.Queries.Common;
using Application.Presentations.Queries.Common;
using MediatR;
using System.Collections.Generic;

namespace Application.Presentations.Queries.GetPresentationDetails
{
    public class GetPresentationDetailsQuery : IRequest<PresentationVm>
    {
        public int Id { get; set; }
    }
}