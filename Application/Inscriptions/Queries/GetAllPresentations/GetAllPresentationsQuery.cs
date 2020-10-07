using Application.Presentations.Queries.Common;
using MediatR;

namespace Application.Inscriptions.Queries.GetAllPresentations
{
    public class GetAllPresentationsQuery : IRequest<PresentationListVm>
    {
        public int Id { get; set; }
    }
}
